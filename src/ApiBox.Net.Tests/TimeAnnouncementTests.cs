using System.Threading.Tasks;
using Xunit;

namespace ApiBox.Net.Tests
{
    public class TimeAnnouncementTests : IClassFixture<TimeAnnouncementFixture>
    {
        private readonly TimeAnnouncementFixture fixture;

        public TimeAnnouncementTests(TimeAnnouncementFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData(ApiStack.WebApi, 100)]
        [InlineData(ApiStack.WebApi, 1000)]
        [InlineData(ApiStack.WebApi, 10000)]
        [InlineData(ApiStack.WebApi, 100000)]
        [InlineData(ApiStack.OData, 100)]
        [InlineData(ApiStack.OData, 1000)]
        [InlineData(ApiStack.OData, 10000)]
        [InlineData(ApiStack.OData, 100000)]
        [InlineData(ApiStack.GQLnet_TypesFirst, 100)]
        [InlineData(ApiStack.GQLnet_TypesFirst, 1000)]
        [InlineData(ApiStack.GQLnet_TypesFirst, 10000)]
        [InlineData(ApiStack.GQLnet_TypesFirst, 100000)]
        public async Task Measure_TimeAnnouncement_Sequential(ApiStack apiStack, int numberOfsamples)
        {
            var action = this.fixture.GetActionFor(apiStack);
            await this.fixture.MeasureAsync(action, apiStack, numberOfsamples).ConfigureAwait(false);
        }
    }
}
