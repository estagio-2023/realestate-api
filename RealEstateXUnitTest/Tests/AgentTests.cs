using AutoMapper;
using AutoMapper.EquivalencyExpression;
using RealEstateApi.Dto.Request;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateXUnitTest.Tests
{
    public class AgentTests
    {
        private readonly IMapper _mapper;
        private readonly RSFixture _fixture;

        public AgentTests() { 
            _fixture = new RSFixture();
            _fixture.Initialize();
            _mapper = new Mapper (new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddCollectionMappers();
            }));
        }

        [Fact]
        public async Task ShouldAddAgent()
        {
            var agentService = GetInstance();

            var agentData = new AgentRequestDto
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890"
            };

            var result = await agentService.AddAgentAsync(agentData);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("John Doe", result.Result.Name);

            var savedAgent = await _fixture.DbContext.Agents.FindAsync(result.Result.Id);
            Assert.NotNull(savedAgent);
            Assert.Equal("John Doe", savedAgent.Name);
        }

        [Fact]
        public async Task ShouldGetAllAgents()
        {
            var agentService = GetInstance();

            _fixture.DbContext.Agents.Add(new Agent { Name = "Lebron James", Email = "james@lebron.com", PhoneNumber = "987654321" });
            _fixture.DbContext.Agents.Add(new Agent { Name = "James Lebron", Email = "lebron@james.com", PhoneNumber = "987654321" });
            await _fixture.DbContext.SaveChangesAsync();

            var result = await agentService.GetAllAgentsAsync();

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Result.Count);
            Assert.Contains(result.Result, agent => agent.Name == "Lebron James");
            Assert.Contains(result.Result, agent => agent.Name == "James Lebron");
        }


        [Fact]
        public async Task ShouldGetAgentById()
        {
            var agentService = GetInstance();

            var agent = new Agent { Name = "testeId", Email = "testeId@example.com", PhoneNumber = "1234567890" };
            _fixture.DbContext.Agents.Add(agent);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await agentService.GetAgentByIdAsync(agent.Id);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("testeId", result.Result.Name);
        }

        [Fact]
        public async Task ShouldUpdateAgent()
        {
            var agentService = GetInstance();

            var agent = new Agent { Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" };
            _fixture.DbContext.Agents.Add(agent);
            await _fixture.DbContext.SaveChangesAsync();

            var updatedAgentData = new AgentRequestDto
            {
                Name = "Jane Doe",
                Email = "jane.doe@example.com",
                PhoneNumber = "0987654321"
            };

            var result = await agentService.PutAgentByIdAsync(agent.Id, updatedAgentData);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("Jane Doe", result.Result.Name);

            var updatedAgent = await _fixture.DbContext.Agents.FindAsync(agent.Id);
            Assert.NotNull(updatedAgent);
            Assert.Equal("Jane Doe", updatedAgent.Name);
        }

        [Fact]
        public async Task ShouldDeleteAgent()
        {

            var agentService = GetInstance();

            var agent = new Agent { Name = "deleted", Email = "deleted@example.com", PhoneNumber = "1234567890" };
            _fixture.DbContext.Agents.Add(agent);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await agentService.DeleteAgentByIdAsync(agent.Id);

            Assert.True(result.IsSuccess);

            var deletedAgent = await _fixture.DbContext.Agents.FindAsync(agent.Id);
            Assert.Null(deletedAgent);
        }

        private IAgentService GetInstance()
        {
            return new AgentService(_fixture.DbContext, _mapper);
        }
    }
}