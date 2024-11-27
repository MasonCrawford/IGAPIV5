using Microsoft.Extensions.Logging;
using Moq;
using TradingService.Services;

namespace TradeLoop.test;

public class OrderServiceTests
{
    private readonly OrderService _testee;

    
    public OrderServiceTests()
    {
        _testee = new OrderService(Mock.Of<ILogger<OrderService>>());
    }
}


// 20220126005039
// https://ig-api.azurewebsites.net/api/TradingChart/getfull/AUDUSD
//
// {
//   "chartCode": "AUDUSD",
//   "prices": [
//     {
//       "openPrice": {
//         "bid": 0.713820,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "a872b496-7b05-4a11-b910-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714150,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714195,
//         "id": "74a47af7-79f4-4fd2-b90d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714210,
//         "ask": 0.714270,
//         "lastTraded": null,
//         "mid": 0.714240,
//         "id": "ff31d481-bd95-49aa-b90e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713790,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713825,
//         "id": "51f07aa5-bb1d-4894-b90f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "034e0294-6405-4c28-13af-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713570,
//         "ask": 0.713630,
//         "lastTraded": null,
//         "mid": 0.713600,
//         "id": "837b6c05-6db4-4081-b90c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713800,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713845,
//         "id": "80970a41-bff7-41e6-b909-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713870,
//         "ask": 0.713960,
//         "lastTraded": null,
//         "mid": 0.713915,
//         "id": "d655a499-dad3-4287-b90a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713410,
//         "ask": 0.713470,
//         "lastTraded": null,
//         "mid": 0.713440,
//         "id": "d32a6b45-3d71-4567-b90b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "eaa45ea4-90e8-48b5-13ae-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "615a2ee9-1f70-458f-b908-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713580,
//         "ask": 0.713640,
//         "lastTraded": null,
//         "mid": 0.713610,
//         "id": "46543a54-e550-4fff-b905-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714040,
//         "ask": 0.714100,
//         "lastTraded": null,
//         "mid": 0.714070,
//         "id": "856591ee-3f27-4b85-b906-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713350,
//         "ask": 0.713420,
//         "lastTraded": null,
//         "mid": 0.713385,
//         "id": "8c04337f-5035-4f91-b907-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "bbf2df73-2108-4cb4-13ad-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714130,
//         "ask": 0.714220,
//         "lastTraded": null,
//         "mid": 0.714175,
//         "id": "2b2c2716-f0c1-4f5e-b904-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713950,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713980,
//         "id": "593443b3-e47c-4830-b901-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714250,
//         "ask": 0.714310,
//         "lastTraded": null,
//         "mid": 0.714280,
//         "id": "bb9343df-5e0e-4907-b902-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713900,
//         "ask": 0.713960,
//         "lastTraded": null,
//         "mid": 0.713930,
//         "id": "d95ce5a1-900e-4aab-b903-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "cb2132b0-326c-48cc-13ac-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714130,
//         "ask": 0.714220,
//         "lastTraded": null,
//         "mid": 0.714175,
//         "id": "a66e4cd0-76ec-4978-b5e4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714100,
//         "ask": 0.714160,
//         "lastTraded": null,
//         "mid": 0.714130,
//         "id": "6366c446-937f-41f2-b5e1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714250,
//         "ask": 0.714310,
//         "lastTraded": null,
//         "mid": 0.714280,
//         "id": "c6bfd997-164f-4f2f-b5e2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714000,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714035,
//         "id": "c46ee191-5304-4c89-b5e3-08d9e02004b3"
//       },
//       "movingAverage": 0.713393,
//       "isRed": true,
//       "id": "a0b22d0c-8f28-4756-12e4-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714280,
//         "ask": 0.714340,
//         "lastTraded": null,
//         "mid": 0.714310,
//         "id": "caf40e4e-4d94-4506-b5e8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714150,
//         "ask": 0.714210,
//         "lastTraded": null,
//         "mid": 0.714180,
//         "id": "7a369749-99f2-414e-b5e5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714430,
//         "ask": 0.714500,
//         "lastTraded": null,
//         "mid": 0.714465,
//         "id": "614c9ee4-f070-43cf-b5e6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713970,
//         "ask": 0.714040,
//         "lastTraded": null,
//         "mid": 0.714005,
//         "id": "1e1dae8f-d4e4-4895-b5e7-08d9e02004b3"
//       },
//       "movingAverage": 0.713355,
//       "isRed": true,
//       "id": "3cf8a309-39c6-483d-12e5-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714000,
//         "ask": 0.714060,
//         "lastTraded": null,
//         "mid": 0.714030,
//         "id": "37f3612f-621a-4fef-b5ec-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714290,
//         "ask": 0.714350,
//         "lastTraded": null,
//         "mid": 0.714320,
//         "id": "ad1b415d-808d-419e-b5e9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714400,
//         "ask": 0.714460,
//         "lastTraded": null,
//         "mid": 0.714430,
//         "id": "884199b8-3c6e-40c8-b5ea-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713970,
//         "ask": 0.714030,
//         "lastTraded": null,
//         "mid": 0.714000,
//         "id": "48243ba4-1e1c-4c44-b5eb-08d9e02004b3"
// //       },
//       "movingAverage": 0.713329,
//       "isRed": false,
//       "id": "21ddb0a4-6ec2-4849-12e6-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713360,
//         "ask": 0.713420,
//         "lastTraded": null,
//         "mid": 0.713390,
//         "id": "3bb58547-3652-482a-b5f0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "d06a7fd6-5188-467a-b5ed-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714040,
//         "ask": 0.714100,
//         "lastTraded": null,
//         "mid": 0.714070,
//         "id": "2762044e-4d6c-455c-b5ee-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713290,
//         "ask": 0.713350,
//         "lastTraded": null,
//         "mid": 0.713320,
//         "id": "782c921f-66f3-499e-b5ef-08d9e02004b3"
//       },
//       "movingAverage": 0.713296,
//       "isRed": false,
//       "id": "57768070-032f-4b32-12e7-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713430,
//         "ask": 0.713490,
//         "lastTraded": null,
//         "mid": 0.713460,
//         "id": "38fc8aa6-66bf-4669-b5f4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713350,
//         "ask": 0.713410,
//         "lastTraded": null,
//         "mid": 0.713380,
//         "id": "5843285f-5a4c-4ec8-b5f1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713670,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713700,
//         "id": "b962f9d2-3c89-4256-b5f2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713220,
//         "ask": 0.713280,
//         "lastTraded": null,
//         "mid": 0.713250,
//         "id": "be459b47-bfb8-4c87-b5f3-08d9e02004b3"
//       },
//       "movingAverage": 0.713266,
//       "isRed": true,
//       "id": "0f84a86a-2053-4eae-12e8-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713580,
//         "ask": 0.713640,
//         "lastTraded": null,
//         "mid": 0.713610,
//         "id": "7001f50b-c41b-4299-b5f8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713420,
//         "ask": 0.713480,
//         "lastTraded": null,
//         "mid": 0.713450,
//         "id": "01a01ca2-bee6-482b-b5f5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713850,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713885,
//         "id": "70c0e84b-f42e-4f54-b5f6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713190,
//         "ask": 0.713280,
//         "lastTraded": null,
//         "mid": 0.713235,
//         "id": "68cf378f-fe65-4bc4-b5f7-08d9e02004b3"
//       },
//       "movingAverage": 0.713248,
//       "isRed": true,
//       "id": "c1d84f00-71f2-486e-12e9-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713970,
//         "ask": 0.714030,
//         "lastTraded": null,
//         "mid": 0.714000,
//         "id": "bfd41583-d665-41ea-b5fc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "eb910859-5f01-4e14-b5f9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714040,
//         "ask": 0.714100,
//         "lastTraded": null,
//         "mid": 0.714070,
//         "id": "2dd3fcc9-594f-4cca-b5fa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713490,
//         "ask": 0.713550,
//         "lastTraded": null,
//         "mid": 0.713520,
//         "id": "c8badd40-6576-4882-b5fb-08d9e02004b3"
//       },
//       "movingAverage": 0.713234,
//       "isRed": true,
//       "id": "f6f17c24-cc15-4105-12ea-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "197e75e2-a5d0-483b-b600-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714000,
//         "ask": 0.714060,
//         "lastTraded": null,
//         "mid": 0.714030,
//         "id": "0faf0a1b-4cca-42ac-b5fd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "f78d2fcf-3681-479e-b5fe-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713620,
//         "ask": 0.713680,
//         "lastTraded": null,
//         "mid": 0.713650,
//         "id": "a528b7bb-f31d-483a-b5ff-08d9e02004b3"
//       },
//       "movingAverage": 0.713215,
//       "isRed": true,
//       "id": "dffde64e-ad26-4ebe-12eb-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715290,
//         "ask": 0.715350,
//         "lastTraded": null,
//         "mid": 0.715320,
//         "id": "d0b17b4b-8947-4789-b604-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714870,
//         "ask": 0.714930,
//         "lastTraded": null,
//         "mid": 0.714900,
//         "id": "5486a866-1ae3-456c-b601-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715320,
//         "ask": 0.715380,
//         "lastTraded": null,
//         "mid": 0.715350,
//         "id": "64f5c7df-fb6b-4182-b602-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714860,
//         "ask": 0.714920,
//         "lastTraded": null,
//         "mid": 0.714890,
//         "id": "dc2ad907-0a97-45cd-b603-08d9e02004b3"
//       },
//       "movingAverage": 0.713193,
//       "isRed": true,
//       "id": "339795d7-54af-4d4f-12ec-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714800,
//         "ask": 0.714860,
//         "lastTraded": null,
//         "mid": 0.714830,
//         "id": "e55f0c89-9557-4c79-b608-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715270,
//         "ask": 0.715330,
//         "lastTraded": null,
//         "mid": 0.715300,
//         "id": "3c67ba14-1607-4291-b605-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715500,
//         "ask": 0.715560,
//         "lastTraded": null,
//         "mid": 0.715530,
//         "id": "9f8f9fd2-8e97-4e5a-b606-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714720,
//         "ask": 0.714780,
//         "lastTraded": null,
//         "mid": 0.714750,
//         "id": "ff4049f2-1368-41b9-b607-08d9e02004b3"
//       },
//       "movingAverage": 0.713152,
//       "isRed": false,
//       "id": "5269505c-d294-4119-12ed-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714830,
//         "ask": 0.714900,
//         "lastTraded": null,
//         "mid": 0.714865,
//         "id": "0f40744f-04b2-4ebe-b60c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714780,
//         "ask": 0.714840,
//         "lastTraded": null,
//         "mid": 0.714810,
//         "id": "b2f6bb9c-b3d9-4056-b609-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715120,
//         "ask": 0.715180,
//         "lastTraded": null,
//         "mid": 0.715150,
//         "id": "841b75db-5ee2-4688-b60a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714540,
//         "ask": 0.714600,
//         "lastTraded": null,
//         "mid": 0.714570,
//         "id": "1360728f-a2d9-4297-b60b-08d9e02004b3"
//       },
//       "movingAverage": 0.713107,
//       "isRed": true,
//       "id": "c3dd538c-d2a9-469a-12ee-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714820,
//         "ask": 0.714880,
//         "lastTraded": null,
//         "mid": 0.714850,
//         "id": "0cc45eb8-044e-4c3f-b610-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714800,
//         "ask": 0.714890,
//         "lastTraded": null,
//         "mid": 0.714845,
//         "id": "3c315bc3-a535-453b-b60d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715200,
//         "ask": 0.715260,
//         "lastTraded": null,
//         "mid": 0.715230,
//         "id": "a3dd39bd-5c31-4eac-b60e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714480,
//         "ask": 0.714540,
//         "lastTraded": null,
//         "mid": 0.714510,
//         "id": "d406f47b-c72e-4a54-b60f-08d9e02004b3"
//       },
//       "movingAverage": 0.713077,
//       "isRed": true,
//       "id": "9ef8fc37-75d0-4eaa-12ef-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714740,
//         "ask": 0.714800,
//         "lastTraded": null,
//         "mid": 0.714770,
//         "id": "e50e0037-3690-4721-b614-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714800,
//         "ask": 0.714860,
//         "lastTraded": null,
//         "mid": 0.714830,
//         "id": "20e187ac-8519-41a5-b611-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714960,
//         "ask": 0.715020,
//         "lastTraded": null,
//         "mid": 0.714990,
//         "id": "fa841deb-5a85-4da5-b612-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714400,
//         "ask": 0.714460,
//         "lastTraded": null,
//         "mid": 0.714430,
//         "id": "04fcae89-8aac-4b36-b613-08d9e02004b3"
//       },
//       "movingAverage": 0.713055,
//       "isRed": false,
//       "id": "d19b285d-e635-4b23-12f0-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713630,
//         "ask": 0.713690,
//         "lastTraded": null,
//         "mid": 0.713660,
//         "id": "56f6bac3-c4f8-4b9f-b618-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714730,
//         "ask": 0.714790,
//         "lastTraded": null,
//         "mid": 0.714760,
//         "id": "e6ddf974-d023-4a55-b615-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714790,
//         "ask": 0.714850,
//         "lastTraded": null,
//         "mid": 0.714820,
//         "id": "423f08b6-9202-4299-b616-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713570,
//         "ask": 0.713630,
//         "lastTraded": null,
//         "mid": 0.713600,
//         "id": "aefd1a37-9805-464f-b617-08d9e02004b3"
//       },
//       "movingAverage": 0.713036,
//       "isRed": false,
//       "id": "fa91231a-df05-4865-12f1-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713520,
//         "ask": 0.713580,
//         "lastTraded": null,
//         "mid": 0.713550,
//         "id": "b6d859cd-01d8-453b-b61c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713640,
//         "ask": 0.713700,
//         "lastTraded": null,
//         "mid": 0.713670,
//         "id": "486f5fd8-e013-487f-b619-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713890,
//         "ask": 0.713950,
//         "lastTraded": null,
//         "mid": 0.713920,
//         "id": "0eab5ac0-d8e8-470b-b61a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713230,
//         "ask": 0.713290,
//         "lastTraded": null,
//         "mid": 0.713260,
//         "id": "d31b385d-ead6-40e3-b61b-08d9e02004b3"
//       },
//       "movingAverage": 0.713015,
//       "isRed": false,
//       "id": "2327808f-0aa6-4f45-12f2-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713500,
//         "ask": 0.713560,
//         "lastTraded": null,
//         "mid": 0.713530,
//         "id": "0e9e16d4-759f-4693-b620-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713540,
//         "ask": 0.713600,
//         "lastTraded": null,
//         "mid": 0.713570,
//         "id": "492b6e67-6a6d-4d65-b61d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713740,
//         "ask": 0.713800,
//         "lastTraded": null,
//         "mid": 0.713770,
//         "id": "15b90f4c-b376-4414-b61e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713360,
//         "ask": 0.713420,
//         "lastTraded": null,
//         "mid": 0.713390,
//         "id": "8f8f46f1-9892-4598-b61f-08d9e02004b3"
//       },
//       "movingAverage": 0.713025,
//       "isRed": false,
//       "id": "f466cef8-40fd-4e24-12f3-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712390,
//         "ask": 0.712450,
//         "lastTraded": null,
//         "mid": 0.712420,
//         "id": "bc4205c8-d7e3-48d6-b624-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713510,
//         "ask": 0.713570,
//         "lastTraded": null,
//         "mid": 0.713540,
//         "id": "43d643ff-09bf-453c-b621-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713510,
//         "ask": 0.713610,
//         "lastTraded": null,
//         "mid": 0.713560,
//         "id": "237f1095-c4f2-4e21-b622-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712300,
//         "ask": 0.712360,
//         "lastTraded": null,
//         "mid": 0.712330,
//         "id": "0f1891f4-f3d8-4897-b623-08d9e02004b3"
//       },
//       "movingAverage": 0.713035,
//       "isRed": false,
//       "id": "232fd4d6-8bad-4125-12f4-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712330,
//         "ask": 0.712390,
//         "lastTraded": null,
//         "mid": 0.712360,
//         "id": "3a011122-a503-4e37-b628-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712410,
//         "ask": 0.712470,
//         "lastTraded": null,
//         "mid": 0.712440,
//         "id": "2e3f5f48-c267-41b0-b625-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712650,
//         "ask": 0.712710,
//         "lastTraded": null,
//         "mid": 0.712680,
//         "id": "b1c16e9f-1c5e-4f8e-b626-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712200,
//         "ask": 0.712260,
//         "lastTraded": null,
//         "mid": 0.712230,
//         "id": "61daa480-8800-4328-b627-08d9e02004b3"
//       },
//       "movingAverage": 0.713044,
//       "isRed": false,
//       "id": "3807d140-77c7-49ca-12f5-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712740,
//         "ask": 0.712850,
//         "lastTraded": null,
//         "mid": 0.712795,
//         "id": "ce120c87-fb77-460e-b62c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712350,
//         "ask": 0.712410,
//         "lastTraded": null,
//         "mid": 0.712380,
//         "id": "385d549a-53c9-4f8a-b629-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713050,
//         "ask": 0.713110,
//         "lastTraded": null,
//         "mid": 0.713080,
//         "id": "54a134c3-2555-40a4-b62a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712140,
//         "ask": 0.712200,
//         "lastTraded": null,
//         "mid": 0.712170,
//         "id": "f4e1422d-f629-4fcc-b62b-08d9e02004b3"
//       },
//       "movingAverage": 0.713068,
//       "isRed": true,
//       "id": "4911cd92-9a65-4bc6-12f6-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712660,
//         "ask": 0.712750,
//         "lastTraded": null,
//         "mid": 0.712705,
//         "id": "11dd9365-378c-4443-b630-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712720,
//         "ask": 0.712900,
//         "lastTraded": null,
//         "mid": 0.712810,
//         "id": "4ada96fd-1bff-4331-b62d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712900,
//         "ask": 0.712960,
//         "lastTraded": null,
//         "mid": 0.712930,
//         "id": "f383e49c-5f4e-453e-b62e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712540,
//         "ask": 0.712600,
//         "lastTraded": null,
//         "mid": 0.712570,
//         "id": "88d85ce7-be12-4cba-b62f-08d9e02004b3"
//       },
//       "movingAverage": 0.713096,
//       "isRed": false,
//       "id": "1dea1a05-abbd-4022-12f7-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713030,
//         "ask": 0.713090,
//         "lastTraded": null,
//         "mid": 0.713060,
//         "id": "d5b974db-baab-43fd-b634-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712670,
//         "ask": 0.712760,
//         "lastTraded": null,
//         "mid": 0.712715,
//         "id": "63642b77-4b33-4b80-b631-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713210,
//         "ask": 0.713270,
//         "lastTraded": null,
//         "mid": 0.713240,
//         "id": "eb304d43-83c4-412f-b632-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712610,
//         "ask": 0.712680,
//         "lastTraded": null,
//         "mid": 0.712645,
//         "id": "4cd89c8c-3ce7-45b1-b633-08d9e02004b3"
//       },
//       "movingAverage": 0.713109,
//       "isRed": true,
//       "id": "363ddfe3-7b70-486c-12f8-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713700,
//         "ask": 0.713760,
//         "lastTraded": null,
//         "mid": 0.713730,
//         "id": "70d1c0b8-10f5-4685-b638-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713040,
//         "ask": 0.713100,
//         "lastTraded": null,
//         "mid": 0.713070,
//         "id": "881b52be-c265-4689-b635-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713720,
//         "ask": 0.713780,
//         "lastTraded": null,
//         "mid": 0.713750,
//         "id": "9d8279be-d7c4-4cd1-b636-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713030,
//         "ask": 0.713090,
//         "lastTraded": null,
//         "mid": 0.713060,
//         "id": "44d55401-938a-4021-b637-08d9e02004b3"
//       },
//       "movingAverage": 0.713129,
//       "isRed": true,
//       "id": "41f1825c-6973-4347-12f9-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713900,
//         "ask": 0.713960,
//         "lastTraded": null,
//         "mid": 0.713930,
//         "id": "0717a8ee-fef7-4c15-b63c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713710,
//         "ask": 0.713770,
//         "lastTraded": null,
//         "mid": 0.713740,
//         "id": "934864d9-1c08-4501-b639-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714160,
//         "ask": 0.714220,
//         "lastTraded": null,
//         "mid": 0.714190,
//         "id": "e58866a2-abf2-4e1a-b63a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713550,
//         "ask": 0.713610,
//         "lastTraded": null,
//         "mid": 0.713580,
//         "id": "c153e392-f087-44c8-b63b-08d9e02004b3"
//       },
//       "movingAverage": 0.713147,
//       "isRed": true,
//       "id": "3d250e56-e9bb-40d7-12fa-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713520,
//         "ask": 0.713580,
//         "lastTraded": null,
//         "mid": 0.713550,
//         "id": "30ec3df7-341f-476b-b640-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713880,
//         "ask": 0.713940,
//         "lastTraded": null,
//         "mid": 0.713910,
//         "id": "27348878-54ad-45e8-b63d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714380,
//         "ask": 0.714440,
//         "lastTraded": null,
//         "mid": 0.714410,
//         "id": "dbb038fd-a244-4f96-b63e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713410,
//         "ask": 0.713470,
//         "lastTraded": null,
//         "mid": 0.713440,
//         "id": "f2bf4cc9-2fdc-4727-b63f-08d9e02004b3"
//       },
//       "movingAverage": 0.713156,
//       "isRed": false,
//       "id": "1090bbf0-7311-49fe-12fb-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713430,
//         "ask": 0.713490,
//         "lastTraded": null,
//         "mid": 0.713460,
//         "id": "22fa7b62-e7ee-4e44-b644-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713510,
//         "ask": 0.713570,
//         "lastTraded": null,
//         "mid": 0.713540,
//         "id": "61b29cea-3ce2-4c10-b641-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713930,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713970,
//         "id": "38af2208-73a7-4359-b642-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713180,
//         "ask": 0.713240,
//         "lastTraded": null,
//         "mid": 0.713210,
//         "id": "6d7dd62c-64e9-49ca-b643-08d9e02004b3"
//       },
//       "movingAverage": 0.713166,
//       "isRed": false,
//       "id": "23696b7d-641c-44f8-12fc-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713290,
//         "ask": 0.713350,
//         "lastTraded": null,
//         "mid": 0.713320,
//         "id": "85a82f93-40b6-4ac6-b648-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713420,
//         "ask": 0.713480,
//         "lastTraded": null,
//         "mid": 0.713450,
//         "id": "8762936f-979a-4338-b645-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713540,
//         "ask": 0.713600,
//         "lastTraded": null,
//         "mid": 0.713570,
//         "id": "340db004-f632-490d-b646-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713140,
//         "ask": 0.713200,
//         "lastTraded": null,
//         "mid": 0.713170,
//         "id": "5de6386d-19f0-4175-b647-08d9e02004b3"
//       },
//       "movingAverage": 0.713185,
//       "isRed": false,
//       "id": "61a952d4-b371-4ad7-12fd-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713400,
//         "ask": 0.713460,
//         "lastTraded": null,
//         "mid": 0.713430,
//         "id": "99f8180a-ca7b-43e0-b64c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713300,
//         "ask": 0.713360,
//         "lastTraded": null,
//         "mid": 0.713330,
//         "id": "0e969445-c399-4ce9-b649-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713420,
//         "ask": 0.713480,
//         "lastTraded": null,
//         "mid": 0.713450,
//         "id": "50e91e93-9d2d-40ef-b64a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713190,
//         "ask": 0.713250,
//         "lastTraded": null,
//         "mid": 0.713220,
//         "id": "bb9b552a-ae57-4560-b64b-08d9e02004b3"
//       },
//       "movingAverage": 0.713215,
//       "isRed": true,
//       "id": "ff276115-3c61-4084-12fe-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713150,
//         "ask": 0.713210,
//         "lastTraded": null,
//         "mid": 0.713180,
//         "id": "d32a72fc-d9b5-49d9-b650-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713390,
//         "ask": 0.713450,
//         "lastTraded": null,
//         "mid": 0.713420,
//         "id": "6b71697f-ad41-489d-b64d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713410,
//         "ask": 0.713470,
//         "lastTraded": null,
//         "mid": 0.713440,
//         "id": "62819738-8ea8-42d2-b64e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713050,
//         "ask": 0.713110,
//         "lastTraded": null,
//         "mid": 0.713080,
//         "id": "9e410a19-8328-4cf4-b64f-08d9e02004b3"
//       },
//       "movingAverage": 0.713247,
//       "isRed": false,
//       "id": "e1874e37-55c0-4440-12ff-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713150,
//         "ask": 0.713210,
//         "lastTraded": null,
//         "mid": 0.713180,
//         "id": "0b8dab74-6df5-4ab8-b654-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713120,
//         "ask": 0.713180,
//         "lastTraded": null,
//         "mid": 0.713150,
//         "id": "6d4bea23-24e1-42c4-b651-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713210,
//         "ask": 0.713270,
//         "lastTraded": null,
//         "mid": 0.713240,
//         "id": "ec71e9eb-2973-44cf-b652-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712960,
//         "ask": 0.713020,
//         "lastTraded": null,
//         "mid": 0.712990,
//         "id": "32398098-6903-4a7b-b653-08d9e02004b3"
//       },
//       "movingAverage": 0.713275,
//       "isRed": true,
//       "id": "f38e66d6-df32-4db5-1300-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713280,
//         "ask": 0.713340,
//         "lastTraded": null,
//         "mid": 0.713310,
//         "id": "21d86c0e-0ee8-427b-b658-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713130,
//         "ask": 0.713190,
//         "lastTraded": null,
//         "mid": 0.713160,
//         "id": "896283e2-5d62-46ab-b655-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713350,
//         "ask": 0.713410,
//         "lastTraded": null,
//         "mid": 0.713380,
//         "id": "a40f9c2d-2ba3-4fb1-b656-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713040,
//         "ask": 0.713110,
//         "lastTraded": null,
//         "mid": 0.713075,
//         "id": "43c7065b-78c4-4882-b657-08d9e02004b3"
//       },
//       "movingAverage": 0.713305,
//       "isRed": true,
//       "id": "87f8704f-0124-4fc9-1301-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713110,
//         "ask": 0.713170,
//         "lastTraded": null,
//         "mid": 0.713140,
//         "id": "6addfec4-b73f-4f53-b65c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713270,
//         "ask": 0.713330,
//         "lastTraded": null,
//         "mid": 0.713300,
//         "id": "30756dbd-a9f1-4a4e-b659-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713380,
//         "ask": 0.713440,
//         "lastTraded": null,
//         "mid": 0.713410,
//         "id": "accf35aa-e95c-48a1-b65a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712930,
//         "ask": 0.712990,
//         "lastTraded": null,
//         "mid": 0.712960,
//         "id": "e6daede6-50b6-423e-b65b-08d9e02004b3"
//       },
//       "movingAverage": 0.713341,
//       "isRed": false,
//       "id": "a430c6bf-3f4f-4e3e-1302-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712810,
//         "ask": 0.712870,
//         "lastTraded": null,
//         "mid": 0.712840,
//         "id": "ff644586-4f56-4ff6-b660-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713130,
//         "ask": 0.713190,
//         "lastTraded": null,
//         "mid": 0.713160,
//         "id": "030b0877-6a13-4108-b65d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713330,
//         "ask": 0.713390,
//         "lastTraded": null,
//         "mid": 0.713360,
//         "id": "3b3b854a-7a59-4ae3-b65e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712690,
//         "ask": 0.712750,
//         "lastTraded": null,
//         "mid": 0.712720,
//         "id": "5b46424b-37ee-4813-b65f-08d9e02004b3"
//       },
//       "movingAverage": 0.713374,
//       "isRed": false,
//       "id": "4d8fc75a-8c81-4219-1303-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712930,
//         "ask": 0.712990,
//         "lastTraded": null,
//         "mid": 0.712960,
//         "id": "56272897-1945-4214-b664-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712820,
//         "ask": 0.712880,
//         "lastTraded": null,
//         "mid": 0.712850,
//         "id": "6bb41b58-014d-4c9f-b661-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712950,
//         "ask": 0.713010,
//         "lastTraded": null,
//         "mid": 0.712980,
//         "id": "81fa62f6-892b-46dc-b662-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712650,
//         "ask": 0.712710,
//         "lastTraded": null,
//         "mid": 0.712680,
//         "id": "b485c64d-9197-4e3e-b663-08d9e02004b3"
//       },
//       "movingAverage": 0.713408,
//       "isRed": true,
//       "id": "161d3f95-3834-443c-1304-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713210,
//         "ask": 0.713270,
//         "lastTraded": null,
//         "mid": 0.713240,
//         "id": "5edf71a0-eeaa-49d9-b668-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712940,
//         "ask": 0.713000,
//         "lastTraded": null,
//         "mid": 0.712970,
//         "id": "e8c72429-ca79-4956-b665-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713330,
//         "ask": 0.713390,
//         "lastTraded": null,
//         "mid": 0.713360,
//         "id": "08c99435-f758-4397-b666-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712910,
//         "ask": 0.712970,
//         "lastTraded": null,
//         "mid": 0.712940,
//         "id": "90f17a26-1501-4f83-b667-08d9e02004b3"
//       },
//       "movingAverage": 0.713450,
//       "isRed": true,
//       "id": "987089a8-09f9-463b-1305-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713320,
//         "ask": 0.713380,
//         "lastTraded": null,
//         "mid": 0.713350,
//         "id": "2a60f9bb-15c6-42bb-b66c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713200,
//         "ask": 0.713260,
//         "lastTraded": null,
//         "mid": 0.713230,
//         "id": "0a8ade66-20a4-4822-b669-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713400,
//         "ask": 0.713460,
//         "lastTraded": null,
//         "mid": 0.713430,
//         "id": "0baf0cc9-73d2-463d-b66a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713060,
//         "ask": 0.713120,
//         "lastTraded": null,
//         "mid": 0.713090,
//         "id": "bcf751b3-f005-478b-b66b-08d9e02004b3"
//       },
//       "movingAverage": 0.713495,
//       "isRed": true,
//       "id": "be1896cc-4b8f-46f3-1306-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713060,
//         "ask": 0.713120,
//         "lastTraded": null,
//         "mid": 0.713090,
//         "id": "1f9bbd2d-75eb-449d-b670-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713310,
//         "ask": 0.713370,
//         "lastTraded": null,
//         "mid": 0.713340,
//         "id": "385834c2-c37f-4fd6-b66d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713350,
//         "ask": 0.713410,
//         "lastTraded": null,
//         "mid": 0.713380,
//         "id": "e339b1cb-6456-48b9-b66e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713010,
//         "ask": 0.713070,
//         "lastTraded": null,
//         "mid": 0.713040,
//         "id": "0439920e-a5fd-4381-b66f-08d9e02004b3"
//       },
//       "movingAverage": 0.713533,
//       "isRed": false,
//       "id": "a9762437-9a79-4b4b-1307-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712950,
//         "ask": 0.713010,
//         "lastTraded": null,
//         "mid": 0.712980,
//         "id": "b4ebf3bf-3431-40d5-b674-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713040,
//         "ask": 0.713100,
//         "lastTraded": null,
//         "mid": 0.713070,
//         "id": "f5798c13-a038-458d-b671-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713150,
//         "ask": 0.713220,
//         "lastTraded": null,
//         "mid": 0.713185,
//         "id": "19ecaed4-d15b-4711-b672-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712810,
//         "ask": 0.712870,
//         "lastTraded": null,
//         "mid": 0.712840,
//         "id": "e85ac352-ccad-4bbe-b673-08d9e02004b3"
//       },
//       "movingAverage": 0.713574,
//       "isRed": false,
//       "id": "be571a97-f4d7-4e50-1308-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713080,
//         "ask": 0.713140,
//         "lastTraded": null,
//         "mid": 0.713110,
//         "id": "24239501-0255-464e-b678-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712960,
//         "ask": 0.713020,
//         "lastTraded": null,
//         "mid": 0.712990,
//         "id": "63850c4b-6ef3-46b7-b675-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713260,
//         "ask": 0.713320,
//         "lastTraded": null,
//         "mid": 0.713290,
//         "id": "f3577edd-ac1d-4c74-b676-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712860,
//         "ask": 0.712920,
//         "lastTraded": null,
//         "mid": 0.712890,
//         "id": "ff948bcc-100e-4e03-b677-08d9e02004b3"
//       },
//       "movingAverage": 0.713612,
//       "isRed": true,
//       "id": "530231de-2f73-4e9e-1309-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713120,
//         "ask": 0.713180,
//         "lastTraded": null,
//         "mid": 0.713150,
//         "id": "0b04b283-699c-4637-b67c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713070,
//         "ask": 0.713130,
//         "lastTraded": null,
//         "mid": 0.713100,
//         "id": "33a1022e-e2dc-48a8-b679-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713390,
//         "ask": 0.713460,
//         "lastTraded": null,
//         "mid": 0.713425,
//         "id": "fa9af7de-18f9-4cfd-b67a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713000,
//         "ask": 0.713060,
//         "lastTraded": null,
//         "mid": 0.713030,
//         "id": "e98b62af-8b41-48db-b67b-08d9e02004b3"
//       },
//       "movingAverage": 0.713641,
//       "isRed": true,
//       "id": "ed0cc3db-f4d5-4025-130a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712460,
//         "ask": 0.712520,
//         "lastTraded": null,
//         "mid": 0.712490,
//         "id": "da082fef-c06a-414d-b680-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713130,
//         "ask": 0.713190,
//         "lastTraded": null,
//         "mid": 0.713160,
//         "id": "7dbfac22-6044-4ad2-b67d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713150,
//         "ask": 0.713240,
//         "lastTraded": null,
//         "mid": 0.713195,
//         "id": "c9a7a7c8-8019-4b65-b67e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712460,
//         "ask": 0.712520,
//         "lastTraded": null,
//         "mid": 0.712490,
//         "id": "ca02870d-242d-4f96-b67f-08d9e02004b3"
//       },
//       "movingAverage": 0.713654,
//       "isRed": false,
//       "id": "3d5a5362-6497-4ae2-130b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712510,
//         "ask": 0.712570,
//         "lastTraded": null,
//         "mid": 0.712540,
//         "id": "1c187ce3-827b-4e9e-b684-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712470,
//         "ask": 0.712530,
//         "lastTraded": null,
//         "mid": 0.712500,
//         "id": "d7722b55-c8e5-44b5-b681-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712640,
//         "ask": 0.712700,
//         "lastTraded": null,
//         "mid": 0.712670,
//         "id": "23065b96-2b13-45a7-b682-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712270,
//         "ask": 0.712330,
//         "lastTraded": null,
//         "mid": 0.712300,
//         "id": "ebc8bd33-b826-4a0d-b683-08d9e02004b3"
//       },
//       "movingAverage": 0.713673,
//       "isRed": true,
//       "id": "e44c9281-076e-4b59-130c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712680,
//         "ask": 0.712740,
//         "lastTraded": null,
//         "mid": 0.712710,
//         "id": "edb1f5ee-0fd3-426e-b688-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712520,
//         "ask": 0.712580,
//         "lastTraded": null,
//         "mid": 0.712550,
//         "id": "1d154cc8-e356-4432-b685-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712880,
//         "ask": 0.712940,
//         "lastTraded": null,
//         "mid": 0.712910,
//         "id": "f131e392-af9d-444f-b686-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712510,
//         "ask": 0.712570,
//         "lastTraded": null,
//         "mid": 0.712540,
//         "id": "dd0a624b-cf42-49a3-b687-08d9e02004b3"
//       },
//       "movingAverage": 0.713700,
//       "isRed": true,
//       "id": "42597011-9ecb-4451-130d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712500,
//         "ask": 0.712560,
//         "lastTraded": null,
//         "mid": 0.712530,
//         "id": "03720b25-a605-4db1-b68c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712660,
//         "ask": 0.712720,
//         "lastTraded": null,
//         "mid": 0.712690,
//         "id": "781458e1-db59-4215-b689-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712750,
//         "ask": 0.712810,
//         "lastTraded": null,
//         "mid": 0.712780,
//         "id": "1cbbe564-7814-4c79-b68a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712490,
//         "ask": 0.712550,
//         "lastTraded": null,
//         "mid": 0.712520,
//         "id": "d90b8616-1dc6-4019-b68b-08d9e02004b3"
//       },
//       "movingAverage": 0.713731,
//       "isRed": false,
//       "id": "a4352f4e-f291-443f-130e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712820,
//         "ask": 0.712880,
//         "lastTraded": null,
//         "mid": 0.712850,
//         "id": "9b6273de-161c-450f-b690-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712510,
//         "ask": 0.712570,
//         "lastTraded": null,
//         "mid": 0.712540,
//         "id": "bcee86c4-713d-43bf-b68d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712830,
//         "ask": 0.712890,
//         "lastTraded": null,
//         "mid": 0.712860,
//         "id": "e0e90f39-d618-464e-b68e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712460,
//         "ask": 0.712520,
//         "lastTraded": null,
//         "mid": 0.712490,
//         "id": "28b5e8a4-0ed3-452e-b68f-08d9e02004b3"
//       },
//       "movingAverage": 0.713768,
//       "isRed": true,
//       "id": "72c6a322-3027-4d7e-130f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712800,
//         "ask": 0.712860,
//         "lastTraded": null,
//         "mid": 0.712830,
//         "id": "b0829b48-7ca9-405d-b694-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712800,
//         "ask": 0.712860,
//         "lastTraded": null,
//         "mid": 0.712830,
//         "id": "82d9cee8-18a4-45d2-b691-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712990,
//         "ask": 0.713050,
//         "lastTraded": null,
//         "mid": 0.713020,
//         "id": "77d8f8a6-735d-414b-b692-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712770,
//         "ask": 0.712830,
//         "lastTraded": null,
//         "mid": 0.712800,
//         "id": "fef5385e-1988-4706-b693-08d9e02004b3"
//       },
//       "movingAverage": 0.713814,
//       "isRed": false,
//       "id": "c5f5c03a-f4d2-4312-1310-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712760,
//         "ask": 0.712820,
//         "lastTraded": null,
//         "mid": 0.712790,
//         "id": "4adc3bc1-5019-4a43-b698-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712820,
//         "ask": 0.712880,
//         "lastTraded": null,
//         "mid": 0.712850,
//         "id": "53581a6d-6d2a-4cde-b695-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712860,
//         "ask": 0.712920,
//         "lastTraded": null,
//         "mid": 0.712890,
//         "id": "1b3c1085-3d48-4f72-b696-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712600,
//         "ask": 0.712660,
//         "lastTraded": null,
//         "mid": 0.712630,
//         "id": "45ab46b3-3fda-463f-b697-08d9e02004b3"
//       },
//       "movingAverage": 0.713858,
//       "isRed": false,
//       "id": "db79225c-53a9-441f-1311-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712500,
//         "ask": 0.712560,
//         "lastTraded": null,
//         "mid": 0.712530,
//         "id": "1e2d5ccd-3d51-4416-b69c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712750,
//         "ask": 0.712810,
//         "lastTraded": null,
//         "mid": 0.712780,
//         "id": "cfc7771c-4367-4ddb-b699-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712750,
//         "ask": 0.712810,
//         "lastTraded": null,
//         "mid": 0.712780,
//         "id": "ea1ac27d-8b4d-46b1-b69a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712400,
//         "ask": 0.712460,
//         "lastTraded": null,
//         "mid": 0.712430,
//         "id": "17f507b7-3092-40dd-b69b-08d9e02004b3"
//       },
//       "movingAverage": 0.713889,
//       "isRed": false,
//       "id": "e7da54bc-416d-479e-1312-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712380,
//         "ask": 0.712440,
//         "lastTraded": null,
//         "mid": 0.712410,
//         "id": "f9ab7724-a494-4d06-b6a0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712490,
//         "ask": 0.712550,
//         "lastTraded": null,
//         "mid": 0.712520,
//         "id": "cd1fd7aa-e55b-48ff-b69d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712620,
//         "ask": 0.712680,
//         "lastTraded": null,
//         "mid": 0.712650,
//         "id": "28071cc4-4b71-48f1-b69e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712290,
//         "ask": 0.712350,
//         "lastTraded": null,
//         "mid": 0.712320,
//         "id": "679da352-ccd1-41f0-b69f-08d9e02004b3"
//       },
//       "movingAverage": 0.713913,
//       "isRed": false,
//       "id": "78778ac2-b9d5-465c-1313-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712310,
//         "ask": 0.712370,
//         "lastTraded": null,
//         "mid": 0.712340,
//         "id": "1580cc2f-ca96-4d02-b6a4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712370,
//         "ask": 0.712430,
//         "lastTraded": null,
//         "mid": 0.712400,
//         "id": "de41f274-0eeb-4d26-b6a1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712480,
//         "ask": 0.712540,
//         "lastTraded": null,
//         "mid": 0.712510,
//         "id": "29ff5bb8-e6cd-48f1-b6a2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712180,
//         "ask": 0.712240,
//         "lastTraded": null,
//         "mid": 0.712210,
//         "id": "740985ea-09bf-43a5-b6a3-08d9e02004b3"
//       },
//       "movingAverage": 0.713939,
//       "isRed": false,
//       "id": "793a7202-29d4-4b67-1314-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712160,
//         "ask": 0.712220,
//         "lastTraded": null,
//         "mid": 0.712190,
//         "id": "b37e00f8-6c9d-4c21-b6a8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712320,
//         "ask": 0.712380,
//         "lastTraded": null,
//         "mid": 0.712350,
//         "id": "37fd4f9d-4c97-4338-b6a5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712430,
//         "ask": 0.712490,
//         "lastTraded": null,
//         "mid": 0.712460,
//         "id": "f96386b6-8e6f-4180-b6a6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712160,
//         "ask": 0.712220,
//         "lastTraded": null,
//         "mid": 0.712190,
//         "id": "e138beea-a36d-4410-b6a7-08d9e02004b3"
//       },
//       "movingAverage": 0.713972,
//       "isRed": false,
//       "id": "473afeb7-60a2-473e-1315-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712830,
//         "ask": 0.712890,
//         "lastTraded": null,
//         "mid": 0.712860,
//         "id": "d331b744-d9c8-4872-b6ac-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712170,
//         "ask": 0.712230,
//         "lastTraded": null,
//         "mid": 0.712200,
//         "id": "ae3549cc-95f7-402f-b6a9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712830,
//         "ask": 0.712890,
//         "lastTraded": null,
//         "mid": 0.712860,
//         "id": "0737b001-1396-4b21-b6aa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712120,
//         "ask": 0.712180,
//         "lastTraded": null,
//         "mid": 0.712150,
//         "id": "54ead3e6-b101-4506-b6ab-08d9e02004b3"
//       },
//       "movingAverage": 0.714013,
//       "isRed": true,
//       "id": "ee1c28f3-8a2c-4dd4-1316-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712650,
//         "ask": 0.712710,
//         "lastTraded": null,
//         "mid": 0.712680,
//         "id": "6fa756ff-6ce2-4470-b6b0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712840,
//         "ask": 0.712900,
//         "lastTraded": null,
//         "mid": 0.712870,
//         "id": "ff359c2e-a9c6-4d71-b6ad-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712860,
//         "ask": 0.712920,
//         "lastTraded": null,
//         "mid": 0.712890,
//         "id": "8b299ab1-2daa-4fd6-b6ae-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712560,
//         "ask": 0.712620,
//         "lastTraded": null,
//         "mid": 0.712590,
//         "id": "a5ea0558-0fb3-4ab3-b6af-08d9e02004b3"
//       },
//       "movingAverage": 0.714059,
//       "isRed": false,
//       "id": "33a6595b-133c-4227-1317-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712500,
//         "ask": 0.712560,
//         "lastTraded": null,
//         "mid": 0.712530,
//         "id": "966b8e7f-1635-43ae-b6b4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712640,
//         "ask": 0.712700,
//         "lastTraded": null,
//         "mid": 0.712670,
//         "id": "aa3b8d7a-ca3e-448c-b6b1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712720,
//         "ask": 0.712780,
//         "lastTraded": null,
//         "mid": 0.712750,
//         "id": "5869b85f-751f-4794-b6b2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712440,
//         "ask": 0.712500,
//         "lastTraded": null,
//         "mid": 0.712470,
//         "id": "ec448fd9-f141-4569-b6b3-08d9e02004b3"
//       },
//       "movingAverage": 0.714078,
//       "isRed": false,
//       "id": "c862a3ed-4337-4055-1318-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712460,
//         "ask": 0.712520,
//         "lastTraded": null,
//         "mid": 0.712490,
//         "id": "5d4bb9a3-451a-40c7-b6b8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712510,
//         "ask": 0.712570,
//         "lastTraded": null,
//         "mid": 0.712540,
//         "id": "825700be-7d2d-4435-b6b5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712600,
//         "ask": 0.712660,
//         "lastTraded": null,
//         "mid": 0.712630,
//         "id": "31c93c09-6b2b-42bc-b6b6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712300,
//         "ask": 0.712360,
//         "lastTraded": null,
//         "mid": 0.712330,
//         "id": "9894adef-cb99-4b51-b6b7-08d9e02004b3"
//       },
//       "movingAverage": 0.714105,
//       "isRed": false,
//       "id": "317a30a6-628e-4311-1319-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712770,
//         "ask": 0.712830,
//         "lastTraded": null,
//         "mid": 0.712800,
//         "id": "dfea309c-3617-4ad9-b6bc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712450,
//         "ask": 0.712510,
//         "lastTraded": null,
//         "mid": 0.712480,
//         "id": "be087264-29c0-4173-b6b9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712850,
//         "ask": 0.712910,
//         "lastTraded": null,
//         "mid": 0.712880,
//         "id": "ba354525-3057-4aae-b6ba-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712400,
//         "ask": 0.712460,
//         "lastTraded": null,
//         "mid": 0.712430,
//         "id": "8d4f900f-3a54-4cf6-b6bb-08d9e02004b3"
//       },
//       "movingAverage": 0.714139,
//       "isRed": true,
//       "id": "edefebc0-6aaf-4d84-131a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712600,
//         "ask": 0.712660,
//         "lastTraded": null,
//         "mid": 0.712630,
//         "id": "f054a31c-d3d4-4f6d-b6c0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712760,
//         "ask": 0.712820,
//         "lastTraded": null,
//         "mid": 0.712790,
//         "id": "ec476c03-b796-407f-b6bd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712970,
//         "ask": 0.713030,
//         "lastTraded": null,
//         "mid": 0.713000,
//         "id": "a7ba8021-9851-4c0d-b6be-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712330,
//         "ask": 0.712390,
//         "lastTraded": null,
//         "mid": 0.712360,
//         "id": "3e4f2454-404b-49bd-b6bf-08d9e02004b3"
//       },
//       "movingAverage": 0.714171,
//       "isRed": false,
//       "id": "8aca1c9c-c0ea-435b-131b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712910,
//         "ask": 0.712970,
//         "lastTraded": null,
//         "mid": 0.712940,
//         "id": "e20000b4-1561-4fb7-b6c4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712610,
//         "ask": 0.712670,
//         "lastTraded": null,
//         "mid": 0.712640,
//         "id": "c118d1c8-953c-4614-b6c1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712950,
//         "ask": 0.713010,
//         "lastTraded": null,
//         "mid": 0.712980,
//         "id": "7cc7149c-c83a-4b50-b6c2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712610,
//         "ask": 0.712670,
//         "lastTraded": null,
//         "mid": 0.712640,
//         "id": "10ab8299-2157-4985-b6c3-08d9e02004b3"
//       },
//       "movingAverage": 0.714194,
//       "isRed": true,
//       "id": "2383c411-ee6d-4511-131c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712780,
//         "ask": 0.712840,
//         "lastTraded": null,
//         "mid": 0.712810,
//         "id": "4f76b280-0f80-4760-b6c8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712930,
//         "ask": 0.712990,
//         "lastTraded": null,
//         "mid": 0.712960,
//         "id": "791e9dc5-cab2-4c71-b6c5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.712990,
//         "ask": 0.713050,
//         "lastTraded": null,
//         "mid": 0.713020,
//         "id": "aa68c807-54e3-4beb-b6c6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712540,
//         "ask": 0.712600,
//         "lastTraded": null,
//         "mid": 0.712570,
//         "id": "3fa12e27-c48e-418e-b6c7-08d9e02004b3"
//       },
//       "movingAverage": 0.714224,
//       "isRed": false,
//       "id": "bb781de4-d794-4fa6-131d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713060,
//         "ask": 0.713120,
//         "lastTraded": null,
//         "mid": 0.713090,
//         "id": "db7353ba-a88b-40a0-b6cc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712790,
//         "ask": 0.712850,
//         "lastTraded": null,
//         "mid": 0.712820,
//         "id": "cfc1e4a6-39e0-42bd-b6c9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713060,
//         "ask": 0.713120,
//         "lastTraded": null,
//         "mid": 0.713090,
//         "id": "9b73700f-d7a8-4eb4-b6ca-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712770,
//         "ask": 0.712830,
//         "lastTraded": null,
//         "mid": 0.712800,
//         "id": "360c7d4c-4dda-4e7e-b6cb-08d9e02004b3"
//       },
//       "movingAverage": 0.714239,
//       "isRed": true,
//       "id": "de558919-a9f6-43b4-131e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713280,
//         "ask": 0.713340,
//         "lastTraded": null,
//         "mid": 0.713310,
//         "id": "28c2901c-8495-4371-b6d0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713040,
//         "ask": 0.713100,
//         "lastTraded": null,
//         "mid": 0.713070,
//         "id": "ffdf5136-dd35-48c4-b6cd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713460,
//         "ask": 0.713520,
//         "lastTraded": null,
//         "mid": 0.713490,
//         "id": "c7d52e5e-26e0-44b2-b6ce-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713020,
//         "ask": 0.713080,
//         "lastTraded": null,
//         "mid": 0.713050,
//         "id": "083275a1-0b69-446e-b6cf-08d9e02004b3"
//       },
//       "movingAverage": 0.714255,
//       "isRed": true,
//       "id": "ee18b1fe-4b0c-415c-131f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713690,
//         "ask": 0.713750,
//         "lastTraded": null,
//         "mid": 0.713720,
//         "id": "e823cf76-fd14-4243-b6d4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713290,
//         "ask": 0.713350,
//         "lastTraded": null,
//         "mid": 0.713320,
//         "id": "55f14c52-c24a-4c10-b6d1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713690,
//         "ask": 0.713750,
//         "lastTraded": null,
//         "mid": 0.713720,
//         "id": "89b79975-7d3b-4370-b6d2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713250,
//         "ask": 0.713310,
//         "lastTraded": null,
//         "mid": 0.713280,
//         "id": "f0835c24-e6b6-461d-b6d3-08d9e02004b3"
//       },
//       "movingAverage": 0.714267,
//       "isRed": true,
//       "id": "033b2864-c9e2-4372-1320-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "af017661-c8bc-4f91-b6d8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713680,
//         "ask": 0.713740,
//         "lastTraded": null,
//         "mid": 0.713710,
//         "id": "8de3008a-4d8a-4f75-b6d5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713920,
//         "ask": 0.713980,
//         "lastTraded": null,
//         "mid": 0.713950,
//         "id": "103f3036-fd06-4852-b6d6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713600,
//         "ask": 0.713660,
//         "lastTraded": null,
//         "mid": 0.713630,
//         "id": "90e2d666-ae7d-48ab-b6d7-08d9e02004b3"
//       },
//       "movingAverage": 0.714273,
//       "isRed": true,
//       "id": "8af6892b-9db6-4861-1321-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713670,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713700,
//         "id": "b019c8e5-880e-4ca3-b6dc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "b8a76340-b0ea-4e60-b6d9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713880,
//         "ask": 0.713940,
//         "lastTraded": null,
//         "mid": 0.713910,
//         "id": "1974a937-1bc1-4f0e-b6da-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713470,
//         "ask": 0.713530,
//         "lastTraded": null,
//         "mid": 0.713500,
//         "id": "7979d8cd-5f9f-4759-b6db-08d9e02004b3"
//       },
//       "movingAverage": 0.714270,
//       "isRed": false,
//       "id": "ef501327-b729-4278-1322-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714130,
//         "ask": 0.714190,
//         "lastTraded": null,
//         "mid": 0.714160,
//         "id": "9592c6a7-8915-4a19-b6e0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713680,
//         "ask": 0.713740,
//         "lastTraded": null,
//         "mid": 0.713710,
//         "id": "01e1a730-4d27-42d9-b6dd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714190,
//         "ask": 0.714260,
//         "lastTraded": null,
//         "mid": 0.714225,
//         "id": "d7bf65b4-2155-4f74-b6de-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713660,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713695,
//         "id": "54362053-6577-464f-b6df-08d9e02004b3"
//       },
//       "movingAverage": 0.714260,
//       "isRed": true,
//       "id": "616dd990-f1c5-44fa-1323-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714040,
//         "ask": 0.714100,
//         "lastTraded": null,
//         "mid": 0.714070,
//         "id": "40626055-a4d6-4c25-b6e4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714140,
//         "ask": 0.714200,
//         "lastTraded": null,
//         "mid": 0.714170,
//         "id": "b391576a-dd08-447f-b6e1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714150,
//         "ask": 0.714210,
//         "lastTraded": null,
//         "mid": 0.714180,
//         "id": "2a0baab0-f3a1-4579-b6e2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713910,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713940,
//         "id": "e3f14c08-2100-47d0-b6e3-08d9e02004b3"
//       },
//       "movingAverage": 0.714258,
//       "isRed": false,
//       "id": "73a056d8-4281-45c2-1324-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713940,
//         "ask": 0.714000,
//         "lastTraded": null,
//         "mid": 0.713970,
//         "id": "728e5548-36d6-429e-b6e8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "64d14f13-9d4f-4801-b6e5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "4fee7c02-b89b-41a1-b6e6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713770,
//         "ask": 0.713830,
//         "lastTraded": null,
//         "mid": 0.713800,
//         "id": "b5f27d9a-f5a2-4961-b6e7-08d9e02004b3"
//       },
//       "movingAverage": 0.714252,
//       "isRed": false,
//       "id": "0d0d4c43-12b4-4784-1325-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "0b56fe4b-c74d-4192-b6ec-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713930,
//         "ask": 0.713990,
//         "lastTraded": null,
//         "mid": 0.713960,
//         "id": "5787ae6a-9fe3-494e-b6e9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "469c887c-4259-416f-b6ea-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713500,
//         "ask": 0.713560,
//         "lastTraded": null,
//         "mid": 0.713530,
//         "id": "6ece2faa-a51c-4813-b6eb-08d9e02004b3"
//       },
//       "movingAverage": 0.714253,
//       "isRed": false,
//       "id": "104c1f49-3a1f-4867-1326-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713780,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713810,
//         "id": "7d5178cc-420e-41e1-b6f0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713600,
//         "ask": 0.713660,
//         "lastTraded": null,
//         "mid": 0.713630,
//         "id": "cdca0577-352c-433f-b6ed-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "345a16b9-90bf-4daf-b6ee-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "1732afbc-021c-4e43-b6ef-08d9e02004b3"
//       },
//       "movingAverage": 0.714266,
//       "isRed": true,
//       "id": "af7c9ada-2780-47bc-1327-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713430,
//         "ask": 0.713490,
//         "lastTraded": null,
//         "mid": 0.713460,
//         "id": "3da29629-ebbe-451b-b6f4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713790,
//         "ask": 0.713850,
//         "lastTraded": null,
//         "mid": 0.713820,
//         "id": "e80fe16c-1fc6-4af6-b6f1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "81ef9ddc-f6f9-4aaa-b6f2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713430,
//         "ask": 0.713490,
//         "lastTraded": null,
//         "mid": 0.713460,
//         "id": "9d780db8-17d8-4a31-b6f3-08d9e02004b3"
//       },
//       "movingAverage": 0.714282,
//       "isRed": false,
//       "id": "05c6c35b-0862-4769-1328-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713670,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713700,
//         "id": "d6ef2035-5fa7-4057-b6f8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713420,
//         "ask": 0.713480,
//         "lastTraded": null,
//         "mid": 0.713450,
//         "id": "80e69cc6-a877-477c-b6f5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713670,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713700,
//         "id": "c44a66ed-a4b2-4b23-b6f6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713260,
//         "ask": 0.713320,
//         "lastTraded": null,
//         "mid": 0.713290,
//         "id": "25e11ee1-31e6-4370-b6f7-08d9e02004b3"
//       },
//       "movingAverage": 0.714283,
//       "isRed": true,
//       "id": "64a5a0f0-2af1-4e8f-1329-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713950,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713980,
//         "id": "33e2d679-ed53-434a-b6fc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713660,
//         "ask": 0.713720,
//         "lastTraded": null,
//         "mid": 0.713690,
//         "id": "af2092c5-8fb7-4430-b6f9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "9c8342e9-be9d-4422-b6fa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713630,
//         "ask": 0.713690,
//         "lastTraded": null,
//         "mid": 0.713660,
//         "id": "3f15761b-3bc5-4757-b6fb-08d9e02004b3"
//       },
//       "movingAverage": 0.714295,
//       "isRed": true,
//       "id": "7f11c7b3-c32a-4f91-132a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714220,
//         "ask": 0.714280,
//         "lastTraded": null,
//         "mid": 0.714250,
//         "id": "81f10b3e-e878-45c7-b700-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713940,
//         "ask": 0.714000,
//         "lastTraded": null,
//         "mid": 0.713970,
//         "id": "f0408c6f-42ce-4807-b6fd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714270,
//         "ask": 0.714330,
//         "lastTraded": null,
//         "mid": 0.714300,
//         "id": "5abdff1a-2833-4e1a-b6fe-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713820,
//         "ask": 0.713880,
//         "lastTraded": null,
//         "mid": 0.713850,
//         "id": "02a47b5d-5ac8-4451-b6ff-08d9e02004b3"
//       },
//       "movingAverage": 0.714296,
//       "isRed": true,
//       "id": "3a766354-c415-452f-132b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714380,
//         "ask": 0.714440,
//         "lastTraded": null,
//         "mid": 0.714410,
//         "id": "ce9e89c1-1b5b-47c3-b704-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714200,
//         "ask": 0.714260,
//         "lastTraded": null,
//         "mid": 0.714230,
//         "id": "2b126d9d-deb9-4ad2-b701-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714410,
//         "ask": 0.714470,
//         "lastTraded": null,
//         "mid": 0.714440,
//         "id": "ce1a0b06-5ad8-46e1-b702-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "4304597b-8c25-49c2-b703-08d9e02004b3"
//       },
//       "movingAverage": 0.714291,
//       "isRed": true,
//       "id": "cb1d21ad-a36f-4db2-132c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714450,
//         "ask": 0.714510,
//         "lastTraded": null,
//         "mid": 0.714480,
//         "id": "41450aef-e0ed-4891-b708-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714370,
//         "ask": 0.714430,
//         "lastTraded": null,
//         "mid": 0.714400,
//         "id": "e2433190-c253-4570-b705-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714450,
//         "ask": 0.714510,
//         "lastTraded": null,
//         "mid": 0.714480,
//         "id": "f3c81aa6-949f-4956-b706-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714310,
//         "ask": 0.714370,
//         "lastTraded": null,
//         "mid": 0.714340,
//         "id": "40c9af3c-a160-46ef-b707-08d9e02004b3"
//       },
//       "movingAverage": 0.714283,
//       "isRed": true,
//       "id": "2d945d89-6ae3-4e3a-132d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "699d83af-f3f8-452b-b70c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714460,
//         "ask": 0.714520,
//         "lastTraded": null,
//         "mid": 0.714490,
//         "id": "8634496e-fe84-47da-b709-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "9d028dec-2153-4cc1-b70a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714460,
//         "ask": 0.714520,
//         "lastTraded": null,
//         "mid": 0.714490,
//         "id": "be19379a-9316-4316-b70b-08d9e02004b3"
//       },
//       "movingAverage": 0.714274,
//       "isRed": true,
//       "id": "33911d0c-f830-4b14-132e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "9a84d461-0e98-4778-b710-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714900,
//         "ask": 0.714960,
//         "lastTraded": null,
//         "mid": 0.714930,
//         "id": "e9015cfd-b5bc-4a14-b70d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715030,
//         "ask": 0.715090,
//         "lastTraded": null,
//         "mid": 0.715060,
//         "id": "b020949a-5001-4502-b70e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714670,
//         "ask": 0.714730,
//         "lastTraded": null,
//         "mid": 0.714700,
//         "id": "245eba87-e6c9-4da9-b70f-08d9e02004b3"
//       },
//       "movingAverage": 0.714257,
//       "isRed": true,
//       "id": "c3dd87b6-4ea0-48c1-132f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714750,
//         "ask": 0.714810,
//         "lastTraded": null,
//         "mid": 0.714780,
//         "id": "2c817491-f497-4cd7-b714-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714920,
//         "ask": 0.714980,
//         "lastTraded": null,
//         "mid": 0.714950,
//         "id": "5c937ee3-8a84-4a04-b711-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714960,
//         "ask": 0.715020,
//         "lastTraded": null,
//         "mid": 0.714990,
//         "id": "6793cf18-81a0-402a-b712-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714670,
//         "ask": 0.714730,
//         "lastTraded": null,
//         "mid": 0.714700,
//         "id": "6751a586-ad1d-46ff-b713-08d9e02004b3"
//       },
//       "movingAverage": 0.714233,
//       "isRed": false,
//       "id": "e10af8db-7d2b-4c79-1330-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714610,
//         "ask": 0.714670,
//         "lastTraded": null,
//         "mid": 0.714640,
//         "id": "ba28ca66-6c5f-448b-b718-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714760,
//         "ask": 0.714820,
//         "lastTraded": null,
//         "mid": 0.714790,
//         "id": "59cb2af2-0628-44e6-b715-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715000,
//         "ask": 0.715060,
//         "lastTraded": null,
//         "mid": 0.715030,
//         "id": "f3454cf0-8305-493e-b716-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714480,
//         "ask": 0.714540,
//         "lastTraded": null,
//         "mid": 0.714510,
//         "id": "e5ae052a-6c12-48ee-b717-08d9e02004b3"
//       },
//       "movingAverage": 0.714213,
//       "isRed": false,
//       "id": "55c670a1-8731-4fe0-1331-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714970,
//         "ask": 0.715030,
//         "lastTraded": null,
//         "mid": 0.715000,
//         "id": "25d38c93-0b8d-4e62-b71c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714620,
//         "ask": 0.714680,
//         "lastTraded": null,
//         "mid": 0.714650,
//         "id": "67d2f848-8194-4c87-b719-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714980,
//         "ask": 0.715040,
//         "lastTraded": null,
//         "mid": 0.715010,
//         "id": "1e2c35ca-206d-4409-b71a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714540,
//         "ask": 0.714600,
//         "lastTraded": null,
//         "mid": 0.714570,
//         "id": "2b6eb468-768b-43d4-b71b-08d9e02004b3"
//       },
//       "movingAverage": 0.714205,
//       "isRed": true,
//       "id": "66074a1d-7d4c-4035-1332-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "db902b03-eae6-493b-b720-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714960,
//         "ask": 0.715020,
//         "lastTraded": null,
//         "mid": 0.714990,
//         "id": "1fa167ff-8baa-4140-b71d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715120,
//         "ask": 0.715180,
//         "lastTraded": null,
//         "mid": 0.715150,
//         "id": "a0cd611c-5852-4c7c-b71e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714830,
//         "ask": 0.714890,
//         "lastTraded": null,
//         "mid": 0.714860,
//         "id": "e0cc5e8a-7b0b-4969-b71f-08d9e02004b3"
//       },
//       "movingAverage": 0.714185,
//       "isRed": false,
//       "id": "5ffb5cbb-15d1-4640-1333-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714800,
//         "ask": 0.714860,
//         "lastTraded": null,
//         "mid": 0.714830,
//         "id": "156927bc-9b10-4a66-b724-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "6a6f857e-6102-447f-b721-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715060,
//         "ask": 0.715120,
//         "lastTraded": null,
//         "mid": 0.715090,
//         "id": "41bfea57-4cba-4ac8-b722-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714690,
//         "ask": 0.714750,
//         "lastTraded": null,
//         "mid": 0.714720,
//         "id": "31386c78-533d-48df-b723-08d9e02004b3"
//       },
//       "movingAverage": 0.714162,
//       "isRed": false,
//       "id": "7dead02b-6eaa-4eff-1334-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714980,
//         "ask": 0.715040,
//         "lastTraded": null,
//         "mid": 0.715010,
//         "id": "9e73dc72-0187-4f26-b728-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714810,
//         "ask": 0.714870,
//         "lastTraded": null,
//         "mid": 0.714840,
//         "id": "62732d05-8598-46b8-b725-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715190,
//         "ask": 0.715270,
//         "lastTraded": null,
//         "mid": 0.715230,
//         "id": "d9acc75e-e90d-4bcb-b726-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714790,
//         "ask": 0.714870,
//         "lastTraded": null,
//         "mid": 0.714830,
//         "id": "55855eb0-a58b-4cca-b727-08d9e02004b3"
//       },
//       "movingAverage": 0.714139,
//       "isRed": true,
//       "id": "fc24e616-771a-49f2-1335-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715160,
//         "ask": 0.715220,
//         "lastTraded": null,
//         "mid": 0.715190,
//         "id": "c49bf7fb-4a94-4675-b72c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714960,
//         "ask": 0.715020,
//         "lastTraded": null,
//         "mid": 0.714990,
//         "id": "0c53941e-30b5-4a82-b729-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715170,
//         "ask": 0.715230,
//         "lastTraded": null,
//         "mid": 0.715200,
//         "id": "bdc63e09-4692-4e1c-b72a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714790,
//         "ask": 0.714850,
//         "lastTraded": null,
//         "mid": 0.714820,
//         "id": "949099f9-6575-406d-b72b-08d9e02004b3"
//       },
//       "movingAverage": 0.714112,
//       "isRed": true,
//       "id": "de98ad2b-b93b-41d1-1336-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715100,
//         "ask": 0.715190,
//         "lastTraded": null,
//         "mid": 0.715145,
//         "id": "bf668b22-f95c-46e1-b730-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715170,
//         "ask": 0.715230,
//         "lastTraded": null,
//         "mid": 0.715200,
//         "id": "eb106ab2-9d26-4fde-b72d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715360,
//         "ask": 0.715420,
//         "lastTraded": null,
//         "mid": 0.715390,
//         "id": "3e9e0756-afbd-400a-b72e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715040,
//         "ask": 0.715100,
//         "lastTraded": null,
//         "mid": 0.715070,
//         "id": "dd04db3a-f508-4b32-b72f-08d9e02004b3"
//       },
//       "movingAverage": 0.714090,
//       "isRed": false,
//       "id": "029ce785-0151-4ee9-1337-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715370,
//         "ask": 0.715430,
//         "lastTraded": null,
//         "mid": 0.715400,
//         "id": "4cfd62dc-a4a7-47e7-b734-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715090,
//         "ask": 0.715180,
//         "lastTraded": null,
//         "mid": 0.715135,
//         "id": "1f147f75-5916-4429-b731-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715420,
//         "ask": 0.715480,
//         "lastTraded": null,
//         "mid": 0.715450,
//         "id": "a365592f-85e8-444d-b732-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714970,
//         "ask": 0.715040,
//         "lastTraded": null,
//         "mid": 0.715005,
//         "id": "8dced728-28b3-4a55-b733-08d9e02004b3"
//       },
//       "movingAverage": 0.714064,
//       "isRed": true,
//       "id": "7972ad13-cb2f-440e-1338-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "9b5b173b-96e9-4821-b738-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715360,
//         "ask": 0.715420,
//         "lastTraded": null,
//         "mid": 0.715390,
//         "id": "89acc92e-504d-40fe-b735-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715360,
//         "ask": 0.715420,
//         "lastTraded": null,
//         "mid": 0.715390,
//         "id": "13676aa6-7c7e-48dd-b736-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714860,
//         "ask": 0.714920,
//         "lastTraded": null,
//         "mid": 0.714890,
//         "id": "0dd3685e-30c1-476e-b737-08d9e02004b3"
//       },
//       "movingAverage": 0.714040,
//       "isRed": false,
//       "id": "a60b39e2-d8d2-4d60-1339-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714400,
//         "ask": 0.714460,
//         "lastTraded": null,
//         "mid": 0.714430,
//         "id": "219f9333-afbd-43da-b73c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714920,
//         "ask": 0.714980,
//         "lastTraded": null,
//         "mid": 0.714950,
//         "id": "c234a81c-6acf-4e73-b739-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714990,
//         "ask": 0.715050,
//         "lastTraded": null,
//         "mid": 0.715020,
//         "id": "3439986f-582c-4bb3-b73a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714380,
//         "ask": 0.714440,
//         "lastTraded": null,
//         "mid": 0.714410,
//         "id": "4910309b-2865-469e-b73b-08d9e02004b3"
//       },
//       "movingAverage": 0.714008,
//       "isRed": false,
//       "id": "7c083776-d54b-4556-133a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713720,
//         "ask": 0.713780,
//         "lastTraded": null,
//         "mid": 0.713750,
//         "id": "6a7f89e1-89ec-41cb-b740-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714420,
//         "ask": 0.714480,
//         "lastTraded": null,
//         "mid": 0.714450,
//         "id": "73009071-c77e-4ee6-b73d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714490,
//         "ask": 0.714550,
//         "lastTraded": null,
//         "mid": 0.714520,
//         "id": "4a09e0f4-dd46-4bf1-b73e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713630,
//         "ask": 0.713690,
//         "lastTraded": null,
//         "mid": 0.713660,
//         "id": "b4b9c26a-1af0-4a41-b73f-08d9e02004b3"
//       },
//       "movingAverage": 0.713987,
//       "isRed": false,
//       "id": "b29cda32-e009-42d3-133b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714080,
//         "ask": 0.714140,
//         "lastTraded": null,
//         "mid": 0.714110,
//         "id": "56c7b0f6-f7ed-4fdf-b744-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713730,
//         "ask": 0.713790,
//         "lastTraded": null,
//         "mid": 0.713760,
//         "id": "0d35a88d-976a-4177-b741-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714210,
//         "ask": 0.714270,
//         "lastTraded": null,
//         "mid": 0.714240,
//         "id": "fe6c5ae3-b665-40ca-b742-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713630,
//         "ask": 0.713690,
//         "lastTraded": null,
//         "mid": 0.713660,
//         "id": "1b326b3d-4df2-4381-b743-08d9e02004b3"
//       },
//       "movingAverage": 0.713970,
//       "isRed": true,
//       "id": "769cc2e5-7533-45e8-133c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713760,
//         "ask": 0.713820,
//         "lastTraded": null,
//         "mid": 0.713790,
//         "id": "7679669b-ef89-49d6-b748-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "30ebbd83-f8c4-49e2-b745-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714100,
//         "ask": 0.714160,
//         "lastTraded": null,
//         "mid": 0.714130,
//         "id": "def771b9-7e7c-4c51-b746-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713750,
//         "ask": 0.713810,
//         "lastTraded": null,
//         "mid": 0.713780,
//         "id": "531083d4-34a6-450e-b747-08d9e02004b3"
//       },
//       "movingAverage": 0.713962,
//       "isRed": false,
//       "id": "aba4f021-afa5-4c98-133d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714070,
//         "ask": 0.714160,
//         "lastTraded": null,
//         "mid": 0.714115,
//         "id": "bcf01df6-8281-40e9-b74c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713780,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713810,
//         "id": "03ed4297-fc7d-4246-b749-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714240,
//         "ask": 0.714300,
//         "lastTraded": null,
//         "mid": 0.714270,
//         "id": "7845e516-6a52-4699-b74a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713710,
//         "ask": 0.713770,
//         "lastTraded": null,
//         "mid": 0.713740,
//         "id": "daa9a120-9386-43ce-b74b-08d9e02004b3"
//       },
//       "movingAverage": 0.713945,
//       "isRed": true,
//       "id": "a4c6b0af-52eb-4b94-133e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714520,
//         "ask": 0.714580,
//         "lastTraded": null,
//         "mid": 0.714550,
//         "id": "24bb570c-1756-4c57-b750-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "9eaaaa7c-9364-4677-b74d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714610,
//         "ask": 0.714670,
//         "lastTraded": null,
//         "mid": 0.714640,
//         "id": "ef25d5c5-9103-4339-b74e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714080,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714115,
//         "id": "ff2cd70d-45c3-4e29-b74f-08d9e02004b3"
//       },
//       "movingAverage": 0.713930,
//       "isRed": true,
//       "id": "789089a2-8c7b-4be2-133f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714790,
//         "ask": 0.714850,
//         "lastTraded": null,
//         "mid": 0.714820,
//         "id": "1844523d-d185-4ebd-b754-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714510,
//         "ask": 0.714570,
//         "lastTraded": null,
//         "mid": 0.714540,
//         "id": "cad8b3a1-41c6-468e-b751-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715030,
//         "ask": 0.715090,
//         "lastTraded": null,
//         "mid": 0.715060,
//         "id": "aeed41a7-923a-457f-b752-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714470,
//         "ask": 0.714530,
//         "lastTraded": null,
//         "mid": 0.714500,
//         "id": "0f05935f-5611-4edf-b753-08d9e02004b3"
//       },
//       "movingAverage": 0.713907,
//       "isRed": true,
//       "id": "996dbab2-8ebe-45aa-1340-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714990,
//         "ask": 0.715050,
//         "lastTraded": null,
//         "mid": 0.715020,
//         "id": "9f49d241-7778-438c-b758-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714820,
//         "ask": 0.714880,
//         "lastTraded": null,
//         "mid": 0.714850,
//         "id": "7861d0e8-eb4f-4f58-b755-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715160,
//         "ask": 0.715230,
//         "lastTraded": null,
//         "mid": 0.715195,
//         "id": "828204af-965d-46c1-b756-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714810,
//         "ask": 0.714870,
//         "lastTraded": null,
//         "mid": 0.714840,
//         "id": "300c0336-b606-4bd4-b757-08d9e02004b3"
//       },
//       "movingAverage": 0.713879,
//       "isRed": true,
//       "id": "4bfb1486-35b3-41e7-1341-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714340,
//         "ask": 0.714400,
//         "lastTraded": null,
//         "mid": 0.714370,
//         "id": "c4d6d87a-4921-46f6-b75c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715010,
//         "ask": 0.715070,
//         "lastTraded": null,
//         "mid": 0.715040,
//         "id": "7afab082-c03b-485f-b759-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715050,
//         "ask": 0.715120,
//         "lastTraded": null,
//         "mid": 0.715085,
//         "id": "99188380-f261-41c7-b75a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714290,
//         "ask": 0.714350,
//         "lastTraded": null,
//         "mid": 0.714320,
//         "id": "f96432b6-c8cc-4192-b75b-08d9e02004b3"
//       },
//       "movingAverage": 0.713847,
//       "isRed": false,
//       "id": "04417c6f-b399-481b-1342-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713940,
//         "ask": 0.714000,
//         "lastTraded": null,
//         "mid": 0.713970,
//         "id": "ca436be0-e968-4a6e-b760-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714350,
//         "ask": 0.714410,
//         "lastTraded": null,
//         "mid": 0.714380,
//         "id": "5eb7ea70-c720-4a39-b75d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714470,
//         "ask": 0.714540,
//         "lastTraded": null,
//         "mid": 0.714505,
//         "id": "b59c6773-828a-4243-b75e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713710,
//         "ask": 0.713770,
//         "lastTraded": null,
//         "mid": 0.713740,
//         "id": "3a4ccabe-9d47-4f7c-b75f-08d9e02004b3"
//       },
//       "movingAverage": 0.713819,
//       "isRed": false,
//       "id": "113deca6-0b93-479f-1343-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "a25dddc8-6802-4798-b764-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713950,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713980,
//         "id": "ff21fc69-48ff-4cec-b761-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "227fa931-ca71-44e2-b762-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "0f05b9d1-ee07-4d27-b763-08d9e02004b3"
//       },
//       "movingAverage": 0.713814,
//       "isRed": false,
//       "id": "25ff4da9-7922-4681-1344-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714000,
//         "ask": 0.714060,
//         "lastTraded": null,
//         "mid": 0.714030,
//         "id": "c00f40f4-61f5-40bc-b768-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "9af98f86-3fc8-4ea6-b765-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "e1430d6d-bc5e-4572-b766-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713640,
//         "ask": 0.713700,
//         "lastTraded": null,
//         "mid": 0.713670,
//         "id": "998ca433-2835-45da-b767-08d9e02004b3"
//       },
//       "movingAverage": 0.713818,
//       "isRed": true,
//       "id": "3ca54183-9667-40f4-1345-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714400,
//         "ask": 0.714460,
//         "lastTraded": null,
//         "mid": 0.714430,
//         "id": "6dce7bcb-609d-4fa5-b76c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713990,
//         "ask": 0.714050,
//         "lastTraded": null,
//         "mid": 0.714020,
//         "id": "c84bd253-24ee-4e45-b769-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714480,
//         "ask": 0.714540,
//         "lastTraded": null,
//         "mid": 0.714510,
//         "id": "e6f57e5b-2522-405b-b76a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713970,
//         "ask": 0.714030,
//         "lastTraded": null,
//         "mid": 0.714000,
//         "id": "5d8b45a5-6ae5-4914-b76b-08d9e02004b3"
//       },
//       "movingAverage": 0.713825,
//       "isRed": true,
//       "id": "9cf5f14b-991d-4270-1346-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714470,
//         "ask": 0.714530,
//         "lastTraded": null,
//         "mid": 0.714500,
//         "id": "0bca4830-16d1-4080-b770-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714410,
//         "ask": 0.714470,
//         "lastTraded": null,
//         "mid": 0.714440,
//         "id": "aaf6c96b-8013-45dc-b76d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714560,
//         "ask": 0.714620,
//         "lastTraded": null,
//         "mid": 0.714590,
//         "id": "d254e569-05e9-439a-b76e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714100,
//         "ask": 0.714160,
//         "lastTraded": null,
//         "mid": 0.714130,
//         "id": "6318a5e8-d2e9-48a2-b76f-08d9e02004b3"
//       },
//       "movingAverage": 0.713828,
//       "isRed": true,
//       "id": "54cddffe-f281-441e-1347-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "f55d8755-95ca-4ebd-b774-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714460,
//         "ask": 0.714520,
//         "lastTraded": null,
//         "mid": 0.714490,
//         "id": "7743e7ca-4793-4af9-b771-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714560,
//         "ask": 0.714620,
//         "lastTraded": null,
//         "mid": 0.714590,
//         "id": "66a70d71-93be-403c-b772-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713640,
//         "ask": 0.713700,
//         "lastTraded": null,
//         "mid": 0.713670,
//         "id": "44868caa-f057-4986-b773-08d9e02004b3"
//       },
//       "movingAverage": 0.713825,
//       "isRed": false,
//       "id": "ff014e81-d06f-496e-1348-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713950,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713980,
//         "id": "5f709a75-9c4a-4a18-b778-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "c77eb788-ca9a-4f81-b775-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714140,
//         "ask": 0.714200,
//         "lastTraded": null,
//         "mid": 0.714170,
//         "id": "4c6f39f7-f71f-4d12-b776-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713580,
//         "ask": 0.713640,
//         "lastTraded": null,
//         "mid": 0.713610,
//         "id": "010bdd24-9c11-48e7-b777-08d9e02004b3"
//       },
//       "movingAverage": 0.713817,
//       "isRed": true,
//       "id": "7edf5338-a3e7-4f66-1349-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714190,
//         "ask": 0.714250,
//         "lastTraded": null,
//         "mid": 0.714220,
//         "id": "695d4cc7-e46f-485f-b77c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "da902051-2309-4f8a-b779-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714310,
//         "ask": 0.714370,
//         "lastTraded": null,
//         "mid": 0.714340,
//         "id": "1948e571-4ae9-4898-b77a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "79372849-0230-4341-b77b-08d9e02004b3"
//       },
//       "movingAverage": 0.713828,
//       "isRed": true,
//       "id": "d8a339fe-3725-4733-134a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "5f97293b-038c-4316-b780-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714200,
//         "ask": 0.714260,
//         "lastTraded": null,
//         "mid": 0.714230,
//         "id": "556eaa55-70a7-4db0-b77d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714220,
//         "ask": 0.714280,
//         "lastTraded": null,
//         "mid": 0.714250,
//         "id": "5964ea00-1226-425f-b77e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "99ef268d-6d39-4e10-b77f-08d9e02004b3"
//       },
//       "movingAverage": 0.713833,
//       "isRed": false,
//       "id": "066b0400-6e41-42ed-134b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713910,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713940,
//         "id": "a63ca58e-6a24-47e4-b784-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714080,
//         "ask": 0.714140,
//         "lastTraded": null,
//         "mid": 0.714110,
//         "id": "2767b403-fadf-4290-b781-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714160,
//         "ask": 0.714220,
//         "lastTraded": null,
//         "mid": 0.714190,
//         "id": "7424c4c4-39d5-4f50-b782-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713830,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713860,
//         "id": "0e718d5a-e5e9-45fd-b783-08d9e02004b3"
//       },
//       "movingAverage": 0.713829,
//       "isRed": false,
//       "id": "be19d34d-3731-45fe-134c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "888b298d-99f8-4f3d-b788-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713920,
//         "ask": 0.713980,
//         "lastTraded": null,
//         "mid": 0.713950,
//         "id": "5484b671-7ced-48ba-b785-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "b60b906b-18f5-44da-b786-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "b4bc329f-5070-4173-b787-08d9e02004b3"
//       },
//       "movingAverage": 0.713830,
//       "isRed": true,
//       "id": "744e1ccb-6d92-4a0d-134d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713730,
//         "ask": 0.713790,
//         "lastTraded": null,
//         "mid": 0.713760,
//         "id": "cbca45f6-59ff-4996-b78c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714070,
//         "ask": 0.714130,
//         "lastTraded": null,
//         "mid": 0.714100,
//         "id": "f01ac2fb-587a-436c-b789-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714080,
//         "ask": 0.714140,
//         "lastTraded": null,
//         "mid": 0.714110,
//         "id": "57945ad0-88f5-4afa-b78a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713730,
//         "ask": 0.713790,
//         "lastTraded": null,
//         "mid": 0.713760,
//         "id": "83f97247-98f1-442e-b78b-08d9e02004b3"
//       },
//       "movingAverage": 0.713837,
//       "isRed": false,
//       "id": "4982cff7-51fd-42aa-134e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713580,
//         "ask": 0.713640,
//         "lastTraded": null,
//         "mid": 0.713610,
//         "id": "0e7f3d83-0c2e-4aa1-b790-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713720,
//         "ask": 0.713780,
//         "lastTraded": null,
//         "mid": 0.713750,
//         "id": "3d75953f-667d-423e-b78d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713740,
//         "ask": 0.713800,
//         "lastTraded": null,
//         "mid": 0.713770,
//         "id": "55c7ba7a-8379-4c00-b78e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713500,
//         "ask": 0.713560,
//         "lastTraded": null,
//         "mid": 0.713530,
//         "id": "60f89d7c-ce30-4f1a-b78f-08d9e02004b3"
//       },
//       "movingAverage": 0.713833,
//       "isRed": false,
//       "id": "d1ada04d-5d03-4efe-134f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "1ccfc6f9-f078-4b0f-b794-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "945c6f8b-8117-4571-b791-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713890,
//         "ask": 0.713950,
//         "lastTraded": null,
//         "mid": 0.713920,
//         "id": "6d4f2bea-0f9c-48be-b792-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713510,
//         "ask": 0.713570,
//         "lastTraded": null,
//         "mid": 0.713540,
//         "id": "84c6c319-5b2f-41e8-b793-08d9e02004b3"
//       },
//       "movingAverage": 0.713838,
//       "isRed": false,
//       "id": "c7a9f9b4-37a8-4ffc-1350-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713610,
//         "ask": 0.713670,
//         "lastTraded": null,
//         "mid": 0.713640,
//         "id": "98709d90-5531-4635-b798-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713600,
//         "ask": 0.713660,
//         "lastTraded": null,
//         "mid": 0.713630,
//         "id": "ce8cc358-5572-4d85-b795-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713770,
//         "ask": 0.713830,
//         "lastTraded": null,
//         "mid": 0.713800,
//         "id": "907f6d96-af9a-49e6-b796-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713550,
//         "ask": 0.713610,
//         "lastTraded": null,
//         "mid": 0.713580,
//         "id": "ad22cd83-33ce-4659-b797-08d9e02004b3"
//       },
//       "movingAverage": 0.713842,
//       "isRed": true,
//       "id": "d877095e-a5d1-4477-1351-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713490,
//         "ask": 0.713550,
//         "lastTraded": null,
//         "mid": 0.713520,
//         "id": "334673b0-a8e1-42d4-b79c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713620,
//         "ask": 0.713680,
//         "lastTraded": null,
//         "mid": 0.713650,
//         "id": "b2bf8ce7-eabe-4610-b799-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "2e5ea681-ec22-4791-b79a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713330,
//         "ask": 0.713390,
//         "lastTraded": null,
//         "mid": 0.713360,
//         "id": "ede5fae3-7746-45cd-b79b-08d9e02004b3"
//       },
//       "movingAverage": 0.713846,
//       "isRed": false,
//       "id": "ecb6915b-f412-43e1-1352-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713400,
//         "ask": 0.713460,
//         "lastTraded": null,
//         "mid": 0.713430,
//         "id": "6ec54d22-a9e9-4096-b7a0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713500,
//         "ask": 0.713560,
//         "lastTraded": null,
//         "mid": 0.713530,
//         "id": "1b13da0d-5c19-4020-b79d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713560,
//         "ask": 0.713620,
//         "lastTraded": null,
//         "mid": 0.713590,
//         "id": "eee9b78f-a8df-41e7-b79e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713290,
//         "ask": 0.713350,
//         "lastTraded": null,
//         "mid": 0.713320,
//         "id": "83a732f8-d7b1-4636-b79f-08d9e02004b3"
//       },
//       "movingAverage": 0.713845,
//       "isRed": false,
//       "id": "5ee89f1a-9703-4831-1353-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "43116527-67ca-48e5-b7a4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713370,
//         "ask": 0.713430,
//         "lastTraded": null,
//         "mid": 0.713400,
//         "id": "6aea080e-7726-4ccf-b7a1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "f15eb713-a43f-48ec-b7a2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713300,
//         "ask": 0.713360,
//         "lastTraded": null,
//         "mid": 0.713330,
//         "id": "404021da-aec0-4ce4-b7a3-08d9e02004b3"
//       },
//       "movingAverage": 0.713854,
//       "isRed": true,
//       "id": "56ac2752-8a50-4960-1354-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713840,
//         "ask": 0.713900,
//         "lastTraded": null,
//         "mid": 0.713870,
//         "id": "5aa706ab-0d03-40d6-b7a8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713600,
//         "ask": 0.713660,
//         "lastTraded": null,
//         "mid": 0.713630,
//         "id": "4cb2b5e6-a99e-43e5-b7a5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713840,
//         "ask": 0.713900,
//         "lastTraded": null,
//         "mid": 0.713870,
//         "id": "1be9b462-9fd1-4be8-b7a6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713410,
//         "ask": 0.713470,
//         "lastTraded": null,
//         "mid": 0.713440,
//         "id": "b79cbf9f-6402-4e6e-b7a7-08d9e02004b3"
//       },
//       "movingAverage": 0.713870,
//       "isRed": true,
//       "id": "1185fd83-3a30-407b-1355-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714120,
//         "ask": 0.714180,
//         "lastTraded": null,
//         "mid": 0.714150,
//         "id": "e4b5aab6-a325-46c0-b7ac-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713830,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713860,
//         "id": "f1766837-3bce-4257-b7a9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714360,
//         "ask": 0.714420,
//         "lastTraded": null,
//         "mid": 0.714390,
//         "id": "3742213f-9559-464c-b7aa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "daba458a-888e-4d1e-b7ab-08d9e02004b3"
//       },
//       "movingAverage": 0.713890,
//       "isRed": true,
//       "id": "28923be9-1fd1-449b-1356-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714560,
//         "ask": 0.714620,
//         "lastTraded": null,
//         "mid": 0.714590,
//         "id": "5da37e84-64ee-4e1b-b7b0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "b0268cc4-de6e-48da-b7ad-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714580,
//         "ask": 0.714650,
//         "lastTraded": null,
//         "mid": 0.714615,
//         "id": "98079334-6f16-4570-b7ae-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "8409d90d-bea0-4225-b7af-08d9e02004b3"
//       },
//       "movingAverage": 0.713906,
//       "isRed": true,
//       "id": "e32d4651-aa98-4722-1357-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714420,
//         "ask": 0.714480,
//         "lastTraded": null,
//         "mid": 0.714450,
//         "id": "e78835a7-e314-416c-b7b4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714570,
//         "ask": 0.714630,
//         "lastTraded": null,
//         "mid": 0.714600,
//         "id": "be112f08-312c-4952-b7b1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714670,
//         "ask": 0.714740,
//         "lastTraded": null,
//         "mid": 0.714705,
//         "id": "a03fb673-f393-480d-b7b2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714310,
//         "ask": 0.714370,
//         "lastTraded": null,
//         "mid": 0.714340,
//         "id": "89584bc6-6002-45dc-b7b3-08d9e02004b3"
//       },
//       "movingAverage": 0.713915,
//       "isRed": false,
//       "id": "cef4bf1c-b93f-4904-1358-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713850,
//         "ask": 0.713910,
//         "lastTraded": null,
//         "mid": 0.713880,
//         "id": "be51702b-4b63-4c8a-b7b8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714410,
//         "ask": 0.714470,
//         "lastTraded": null,
//         "mid": 0.714440,
//         "id": "b06a917d-fa0e-431c-b7b5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714450,
//         "ask": 0.714510,
//         "lastTraded": null,
//         "mid": 0.714480,
//         "id": "e9df0397-68b4-443f-b7b6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713840,
//         "ask": 0.713900,
//         "lastTraded": null,
//         "mid": 0.713870,
//         "id": "3d409c25-88d0-45dd-b7b7-08d9e02004b3"
//       },
//       "movingAverage": 0.713908,
//       "isRed": false,
//       "id": "26e5bab0-4560-44a2-1359-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713970,
//         "ask": 0.714030,
//         "lastTraded": null,
//         "mid": 0.714000,
//         "id": "de558fba-826e-4fe9-b7bc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "be4cb680-acff-4424-b7b9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714020,
//         "ask": 0.714080,
//         "lastTraded": null,
//         "mid": 0.714050,
//         "id": "8ba103bb-0054-4c9c-b7ba-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "0565a889-3fd0-4e1d-b7bb-08d9e02004b3"
//       },
//       "movingAverage": 0.713913,
//       "isRed": true,
//       "id": "3bc7303b-4c46-4e85-135a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713760,
//         "ask": 0.713820,
//         "lastTraded": null,
//         "mid": 0.713790,
//         "id": "36f6a013-a460-4a9b-b7c0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713980,
//         "ask": 0.714040,
//         "lastTraded": null,
//         "mid": 0.714010,
//         "id": "af865754-f3c0-41da-b7bd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "a80c9f3f-e1da-463b-b7be-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713740,
//         "ask": 0.713800,
//         "lastTraded": null,
//         "mid": 0.713770,
//         "id": "9db941cf-cfc1-4360-b7bf-08d9e02004b3"
//       },
//       "movingAverage": 0.713937,
//       "isRed": false,
//       "id": "01798b38-13db-44d0-135b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713660,
//         "ask": 0.713720,
//         "lastTraded": null,
//         "mid": 0.713690,
//         "id": "2cf69d37-faff-40ab-b7c4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713750,
//         "ask": 0.713810,
//         "lastTraded": null,
//         "mid": 0.713780,
//         "id": "0c8902fe-ff38-4f96-b7c1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "7b68892f-13da-453e-b7c2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713540,
//         "ask": 0.713600,
//         "lastTraded": null,
//         "mid": 0.713570,
//         "id": "d565e8e9-2a7c-47e6-b7c3-08d9e02004b3"
//       },
//       "movingAverage": 0.713955,
//       "isRed": false,
//       "id": "4d828066-955f-40d9-135c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713830,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713860,
//         "id": "5342f25d-0d46-426c-b7c8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713670,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713700,
//         "id": "cfa2479a-d579-4750-b7c5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713990,
//         "ask": 0.714050,
//         "lastTraded": null,
//         "mid": 0.714020,
//         "id": "a1585677-9cc3-465f-b7c6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "64ce4dca-db8b-4c99-b7c7-08d9e02004b3"
//       },
//       "movingAverage": 0.713978,
//       "isRed": true,
//       "id": "13e7ca29-75ed-434b-135d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713910,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713940,
//         "id": "625e755b-bb79-49c9-b7cc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713820,
//         "ask": 0.713880,
//         "lastTraded": null,
//         "mid": 0.713850,
//         "id": "6f6a3a6f-9708-484f-b7c9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "e75e57b8-137d-4dc9-b7ca-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "d67449df-1c06-4b52-b7cb-08d9e02004b3"
//       },
//       "movingAverage": 0.714007,
//       "isRed": true,
//       "id": "2843b2fe-e907-4049-135e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713570,
//         "ask": 0.713630,
//         "lastTraded": null,
//         "mid": 0.713600,
//         "id": "d342da46-1aa5-4343-b7d0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713920,
//         "ask": 0.713980,
//         "lastTraded": null,
//         "mid": 0.713950,
//         "id": "b8fcc42f-f216-4990-b7cd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "791c0440-0a90-496d-b7ce-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713520,
//         "ask": 0.713580,
//         "lastTraded": null,
//         "mid": 0.713550,
//         "id": "c6bace8f-310c-4a74-b7cf-08d9e02004b3"
//       },
//       "movingAverage": 0.714033,
//       "isRed": false,
//       "id": "48e67099-7187-4476-135f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713730,
//         "ask": 0.713790,
//         "lastTraded": null,
//         "mid": 0.713760,
//         "id": "d68e4724-3e6c-4ccd-b7d4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713580,
//         "ask": 0.713640,
//         "lastTraded": null,
//         "mid": 0.713610,
//         "id": "abf83606-f0f0-4800-b7d1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713750,
//         "ask": 0.713810,
//         "lastTraded": null,
//         "mid": 0.713780,
//         "id": "051aa72f-36db-4e69-b7d2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713550,
//         "ask": 0.713610,
//         "lastTraded": null,
//         "mid": 0.713580,
//         "id": "2ad1476d-ca30-467b-b7d3-08d9e02004b3"
//       },
//       "movingAverage": 0.714055,
//       "isRed": true,
//       "id": "54761d6f-812a-4ea1-1360-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713930,
//         "ask": 0.713990,
//         "lastTraded": null,
//         "mid": 0.713960,
//         "id": "02004242-537c-4ec6-b7d8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713710,
//         "ask": 0.713770,
//         "lastTraded": null,
//         "mid": 0.713740,
//         "id": "84216318-ee0d-460f-b7d5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714070,
//         "ask": 0.714130,
//         "lastTraded": null,
//         "mid": 0.714100,
//         "id": "b7f37c9e-5e69-420a-b7d6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713620,
//         "ask": 0.713680,
//         "lastTraded": null,
//         "mid": 0.713650,
//         "id": "f2e942ca-15d8-4130-b7d7-08d9e02004b3"
//       },
//       "movingAverage": 0.714081,
//       "isRed": true,
//       "id": "c951f48c-3235-482d-1361-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714360,
//         "ask": 0.714420,
//         "lastTraded": null,
//         "mid": 0.714390,
//         "id": "4c0edac7-988c-47c2-b7dc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713920,
//         "ask": 0.713980,
//         "lastTraded": null,
//         "mid": 0.713950,
//         "id": "b2556c03-b3a8-4b68-b7d9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714530,
//         "ask": 0.714590,
//         "lastTraded": null,
//         "mid": 0.714560,
//         "id": "f0f3066a-d8fd-4a8a-b7da-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713880,
//         "ask": 0.713940,
//         "lastTraded": null,
//         "mid": 0.713910,
//         "id": "aa8ea66c-930a-40ed-b7db-08d9e02004b3"
//       },
//       "movingAverage": 0.714112,
//       "isRed": true,
//       "id": "b3b02265-c995-4c4f-1362-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713660,
//         "ask": 0.713720,
//         "lastTraded": null,
//         "mid": 0.713690,
//         "id": "46c17e82-23fd-4cdb-b7e0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714350,
//         "ask": 0.714410,
//         "lastTraded": null,
//         "mid": 0.714380,
//         "id": "ed791daa-912f-417f-b7dd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714410,
//         "ask": 0.714470,
//         "lastTraded": null,
//         "mid": 0.714440,
//         "id": "f3a1563e-a71c-4d00-b7de-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713560,
//         "ask": 0.713620,
//         "lastTraded": null,
//         "mid": 0.713590,
//         "id": "d37d2890-81f3-4090-b7df-08d9e02004b3"
//       },
//       "movingAverage": 0.714143,
//       "isRed": false,
//       "id": "9ab95bdd-442f-4f01-1363-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "7458c1fb-069b-4d90-b7e4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "90ba7945-07b6-4ac5-b7e1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713850,
//         "ask": 0.713910,
//         "lastTraded": null,
//         "mid": 0.713880,
//         "id": "28c513d8-b4cf-40f4-b7e2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713530,
//         "ask": 0.713590,
//         "lastTraded": null,
//         "mid": 0.713560,
//         "id": "52c3bf7b-c2c2-4e4d-b7e3-08d9e02004b3"
//       },
//       "movingAverage": 0.714170,
//       "isRed": true,
//       "id": "809f9348-872c-4896-1364-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713790,
//         "ask": 0.713850,
//         "lastTraded": null,
//         "mid": 0.713820,
//         "id": "f67ee458-a694-4074-b7e8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713790,
//         "ask": 0.713850,
//         "lastTraded": null,
//         "mid": 0.713820,
//         "id": "3df52ff3-083c-4b27-b7e5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713930,
//         "ask": 0.713990,
//         "lastTraded": null,
//         "mid": 0.713960,
//         "id": "d9a59be8-8686-45fe-b7e6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713790,
//         "ask": 0.713850,
//         "lastTraded": null,
//         "mid": 0.713820,
//         "id": "471414e1-4f90-4123-b7e7-08d9e02004b3"
//       },
//       "movingAverage": 0.714197,
//       "isRed": false,
//       "id": "5e29578d-3941-4c92-1365-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713440,
//         "ask": 0.713500,
//         "lastTraded": null,
//         "mid": 0.713470,
//         "id": "dd0bbd67-aac2-41df-b7ec-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713780,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713810,
//         "id": "8341bc5e-f13d-4b5c-b7e9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713930,
//         "ask": 0.713990,
//         "lastTraded": null,
//         "mid": 0.713960,
//         "id": "806192fa-9f82-436e-b7ea-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713390,
//         "ask": 0.713450,
//         "lastTraded": null,
//         "mid": 0.713420,
//         "id": "4f5f8782-6103-4b55-b7eb-08d9e02004b3"
//       },
//       "movingAverage": 0.714223,
//       "isRed": false,
//       "id": "88b1a468-a778-43e2-1366-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "441e6604-acc9-4593-b7f0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713430,
//         "ask": 0.713490,
//         "lastTraded": null,
//         "mid": 0.713460,
//         "id": "391b83bd-89a2-408a-b7ed-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713910,
//         "ask": 0.713980,
//         "lastTraded": null,
//         "mid": 0.713945,
//         "id": "c55641ed-bd3b-439a-b7ee-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713380,
//         "ask": 0.713450,
//         "lastTraded": null,
//         "mid": 0.713415,
//         "id": "53f22903-be10-4be2-b7ef-08d9e02004b3"
//       },
//       "movingAverage": 0.714259,
//       "isRed": true,
//       "id": "a624948c-6b12-4e2a-1367-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "ea96c1be-2987-4014-b7f4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "f5ce73b5-02e9-4ce6-b7f1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714050,
//         "ask": 0.714110,
//         "lastTraded": null,
//         "mid": 0.714080,
//         "id": "0134efc7-6868-414b-b7f2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "b4e555b1-6271-403c-b7f3-08d9e02004b3"
//       },
//       "movingAverage": 0.714302,
//       "isRed": true,
//       "id": "50097abe-bced-4d41-1368-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713930,
//         "ask": 0.713990,
//         "lastTraded": null,
//         "mid": 0.713960,
//         "id": "16dd9d77-67a5-4dc8-b7f8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713860,
//         "ask": 0.713920,
//         "lastTraded": null,
//         "mid": 0.713890,
//         "id": "49b9c42f-5c70-4eea-b7f5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "94b2401c-b562-4324-b7f6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "981dbe63-39d1-44a5-b7f7-08d9e02004b3"
//       },
//       "movingAverage": 0.714329,
//       "isRed": true,
//       "id": "a1673b93-1e18-4580-1369-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713780,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713810,
//         "id": "6dade488-0863-4a6b-b7fc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713910,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713940,
//         "id": "1b6fccea-103b-414c-b7f9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "fbaab821-4cd8-4d34-b7fa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713760,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713800,
//         "id": "6332bb10-1a84-4849-b7fb-08d9e02004b3"
//       },
//       "movingAverage": 0.714356,
//       "isRed": false,
//       "id": "b3022872-33e0-4524-136a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "6fc24a95-d5be-4460-b800-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713790,
//         "ask": 0.713850,
//         "lastTraded": null,
//         "mid": 0.713820,
//         "id": "738762de-6b3a-4d3c-b7fd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "6d1c5520-83ed-41c2-b7fe-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713660,
//         "ask": 0.713730,
//         "lastTraded": null,
//         "mid": 0.713695,
//         "id": "8bb2f0f8-afdf-4242-b7ff-08d9e02004b3"
//       },
//       "movingAverage": 0.714376,
//       "isRed": true,
//       "id": "06496863-24cb-401e-136b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713570,
//         "ask": 0.713630,
//         "lastTraded": null,
//         "mid": 0.713600,
//         "id": "4c899965-1b60-417c-b804-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713850,
//         "ask": 0.713910,
//         "lastTraded": null,
//         "mid": 0.713880,
//         "id": "59d20aa3-c068-4550-b801-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713890,
//         "ask": 0.713950,
//         "lastTraded": null,
//         "mid": 0.713920,
//         "id": "e056e615-36f0-452b-b802-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713520,
//         "ask": 0.713580,
//         "lastTraded": null,
//         "mid": 0.713550,
//         "id": "b34da973-bc51-4e46-b803-08d9e02004b3"
//       },
//       "movingAverage": 0.714404,
//       "isRed": false,
//       "id": "08ed91ee-0bce-4ac7-136c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713330,
//         "ask": 0.713390,
//         "lastTraded": null,
//         "mid": 0.713360,
//         "id": "cecfe5e7-1cbb-42af-b808-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "4bf1b0da-9107-4e6b-b805-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713640,
//         "ask": 0.713700,
//         "lastTraded": null,
//         "mid": 0.713670,
//         "id": "baff8cad-183d-47a1-b806-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713300,
//         "ask": 0.713370,
//         "lastTraded": null,
//         "mid": 0.713335,
//         "id": "56eefdb6-765d-4eb4-b807-08d9e02004b3"
//       },
//       "movingAverage": 0.714436,
//       "isRed": false,
//       "id": "d84e2f6c-f587-463d-136d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713220,
//         "ask": 0.713280,
//         "lastTraded": null,
//         "mid": 0.713250,
//         "id": "7e7c90be-09a8-4356-b80c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713340,
//         "ask": 0.713400,
//         "lastTraded": null,
//         "mid": 0.713370,
//         "id": "4035d6ea-389c-47dd-b809-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713390,
//         "ask": 0.713450,
//         "lastTraded": null,
//         "mid": 0.713420,
//         "id": "1ba4a8ce-cff3-492e-b80a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713060,
//         "ask": 0.713120,
//         "lastTraded": null,
//         "mid": 0.713090,
//         "id": "24444dc3-bc8a-4093-b80b-08d9e02004b3"
//       },
//       "movingAverage": 0.714480,
//       "isRed": false,
//       "id": "83dac719-2421-4504-136e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713020,
//         "ask": 0.713080,
//         "lastTraded": null,
//         "mid": 0.713050,
//         "id": "ebe6b5dc-ba3e-4e4e-b810-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713210,
//         "ask": 0.713270,
//         "lastTraded": null,
//         "mid": 0.713240,
//         "id": "a15af7be-20d6-460b-b80d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713270,
//         "ask": 0.713330,
//         "lastTraded": null,
//         "mid": 0.713300,
//         "id": "279efc62-cf01-4e10-b80e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713010,
//         "ask": 0.713070,
//         "lastTraded": null,
//         "mid": 0.713040,
//         "id": "f9454f26-49de-490b-b80f-08d9e02004b3"
//       },
//       "movingAverage": 0.714536,
//       "isRed": false,
//       "id": "8cb697f5-796b-4443-136f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.712980,
//         "ask": 0.713040,
//         "lastTraded": null,
//         "mid": 0.713010,
//         "id": "4121b725-1934-4f12-b814-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713030,
//         "ask": 0.713090,
//         "lastTraded": null,
//         "mid": 0.713060,
//         "id": "07cecec0-6cd0-47e7-b811-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713100,
//         "ask": 0.713160,
//         "lastTraded": null,
//         "mid": 0.713130,
//         "id": "99410039-4692-4425-b812-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712910,
//         "ask": 0.712970,
//         "lastTraded": null,
//         "mid": 0.712940,
//         "id": "877040fe-ca20-4df6-b813-08d9e02004b3"
//       },
//       "movingAverage": 0.714604,
//       "isRed": false,
//       "id": "d5f9c700-075b-4d33-1370-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713110,
//         "ask": 0.713170,
//         "lastTraded": null,
//         "mid": 0.713140,
//         "id": "eb244d52-732c-4503-b818-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.712970,
//         "ask": 0.713030,
//         "lastTraded": null,
//         "mid": 0.713000,
//         "id": "f82e3b9b-3caa-429b-b815-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713180,
//         "ask": 0.713240,
//         "lastTraded": null,
//         "mid": 0.713210,
//         "id": "04bb1f7d-533e-4fa0-b816-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.712950,
//         "ask": 0.713010,
//         "lastTraded": null,
//         "mid": 0.712980,
//         "id": "3268a754-d1bd-4f5e-b817-08d9e02004b3"
//       },
//       "movingAverage": 0.714687,
//       "isRed": true,
//       "id": "45f5a1a3-e30c-440e-1371-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713270,
//         "ask": 0.713290,
//         "lastTraded": null,
//         "mid": 0.713280,
//         "id": "5f10f710-40fa-4591-b81c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713100,
//         "ask": 0.713160,
//         "lastTraded": null,
//         "mid": 0.713130,
//         "id": "1c5bd29d-ead5-4ff3-b819-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713290,
//         "ask": 0.713350,
//         "lastTraded": null,
//         "mid": 0.713320,
//         "id": "ada1bb18-e5b6-4b7a-b81a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713010,
//         "ask": 0.713070,
//         "lastTraded": null,
//         "mid": 0.713040,
//         "id": "5b321e6e-0699-4548-b81b-08d9e02004b3"
//       },
//       "movingAverage": 0.714760,
//       "isRed": true,
//       "id": "e1ce26a3-7203-4691-1372-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "5ffc902b-92cb-42a0-b820-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713200,
//         "ask": 0.713260,
//         "lastTraded": null,
//         "mid": 0.713230,
//         "id": "db2d4855-ed34-421b-b81d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713700,
//         "ask": 0.713760,
//         "lastTraded": null,
//         "mid": 0.713730,
//         "id": "d82e64e4-c5f3-458f-b81e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713110,
//         "ask": 0.713180,
//         "lastTraded": null,
//         "mid": 0.713145,
//         "id": "e84c74a6-c891-49d3-b81f-08d9e02004b3"
//       },
//       "movingAverage": 0.714833,
//       "isRed": true,
//       "id": "d5686028-b3bb-4b13-1373-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "8d4913db-2fbe-4487-b824-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713630,
//         "ask": 0.713690,
//         "lastTraded": null,
//         "mid": 0.713660,
//         "id": "610f3169-f775-46c5-b821-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714120,
//         "ask": 0.714180,
//         "lastTraded": null,
//         "mid": 0.714150,
//         "id": "d35c0807-3011-4e4f-b822-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713610,
//         "ask": 0.713670,
//         "lastTraded": null,
//         "mid": 0.713640,
//         "id": "812bff0c-ee33-4330-b823-08d9e02004b3"
//       },
//       "movingAverage": 0.714868,
//       "isRed": true,
//       "id": "5a904e79-61be-4fe4-1374-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714170,
//         "ask": 0.714230,
//         "lastTraded": null,
//         "mid": 0.714200,
//         "id": "ffb72a50-bd59-44ca-b828-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714080,
//         "ask": 0.714140,
//         "lastTraded": null,
//         "mid": 0.714110,
//         "id": "7cbfbd7a-59df-43cc-b825-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714260,
//         "ask": 0.714320,
//         "lastTraded": null,
//         "mid": 0.714290,
//         "id": "37ec9c37-4c8c-47b3-b826-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714080,
//         "ask": 0.714140,
//         "lastTraded": null,
//         "mid": 0.714110,
//         "id": "6196368f-ee80-417b-b827-08d9e02004b3"
//       },
//       "movingAverage": 0.714899,
//       "isRed": true,
//       "id": "ef387783-de23-4100-1375-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714150,
//         "ask": 0.714210,
//         "lastTraded": null,
//         "mid": 0.714180,
//         "id": "d2ff2735-8be5-49c6-b82c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "70bc7f16-9b66-424b-b829-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714270,
//         "ask": 0.714330,
//         "lastTraded": null,
//         "mid": 0.714300,
//         "id": "d7d1c38b-9879-4e8b-b82a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714030,
//         "ask": 0.714090,
//         "lastTraded": null,
//         "mid": 0.714060,
//         "id": "d52400e5-e954-41a7-b82b-08d9e02004b3"
//       },
//       "movingAverage": 0.714920,
//       "isRed": false,
//       "id": "1af286ad-338c-49ae-1376-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "2cea3849-522d-4252-b830-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714140,
//         "ask": 0.714200,
//         "lastTraded": null,
//         "mid": 0.714170,
//         "id": "83069b03-2af9-4c69-b82d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714410,
//         "ask": 0.714470,
//         "lastTraded": null,
//         "mid": 0.714440,
//         "id": "3fedfa87-f1c2-4254-b82e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714090,
//         "ask": 0.714150,
//         "lastTraded": null,
//         "mid": 0.714120,
//         "id": "32a19403-c264-44e6-b82f-08d9e02004b3"
//       },
//       "movingAverage": 0.714939,
//       "isRed": false,
//       "id": "642503a1-1168-4243-1377-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714270,
//         "ask": 0.714330,
//         "lastTraded": null,
//         "mid": 0.714300,
//         "id": "61959da8-f627-40f5-b834-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714120,
//         "ask": 0.714180,
//         "lastTraded": null,
//         "mid": 0.714150,
//         "id": "a2bcc122-b438-4f9f-b831-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714300,
//         "ask": 0.714360,
//         "lastTraded": null,
//         "mid": 0.714330,
//         "id": "8416a539-1a4d-462c-b832-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "f8dd788c-3928-4cc4-b833-08d9e02004b3"
//       },
//       "movingAverage": 0.714950,
//       "isRed": true,
//       "id": "15003454-d183-43b1-1378-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714040,
//         "ask": 0.714100,
//         "lastTraded": null,
//         "mid": 0.714070,
//         "id": "cab1bd05-491d-4e87-b838-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714280,
//         "ask": 0.714340,
//         "lastTraded": null,
//         "mid": 0.714310,
//         "id": "61730bf0-b519-49ee-b835-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714280,
//         "ask": 0.714340,
//         "lastTraded": null,
//         "mid": 0.714310,
//         "id": "a72c5f17-a222-4e37-b836-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "5f851ac3-a4b7-4768-b837-08d9e02004b3"
//       },
//       "movingAverage": 0.714965,
//       "isRed": false,
//       "id": "c2e032f4-09fe-4143-1379-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714350,
//         "ask": 0.714410,
//         "lastTraded": null,
//         "mid": 0.714380,
//         "id": "43b98f3d-8bdd-4ead-b83c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714060,
//         "ask": 0.714120,
//         "lastTraded": null,
//         "mid": 0.714090,
//         "id": "ad557a11-e95d-4721-b839-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714390,
//         "ask": 0.714460,
//         "lastTraded": null,
//         "mid": 0.714425,
//         "id": "efdd8ceb-a327-4c71-b83a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714050,
//         "ask": 0.714110,
//         "lastTraded": null,
//         "mid": 0.714080,
//         "id": "cfb4f324-3b9c-46fa-b83b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "4fb3b613-85da-46ab-137a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714160,
//         "ask": 0.714220,
//         "lastTraded": null,
//         "mid": 0.714190,
//         "id": "2b7fccbc-58e2-4ea5-b840-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714360,
//         "ask": 0.714420,
//         "lastTraded": null,
//         "mid": 0.714390,
//         "id": "5c9b9256-1d0a-45c6-b83d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714370,
//         "ask": 0.714430,
//         "lastTraded": null,
//         "mid": 0.714400,
//         "id": "20931988-c552-4852-b83e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714110,
//         "ask": 0.714170,
//         "lastTraded": null,
//         "mid": 0.714140,
//         "id": "ed389eae-9345-4cbb-b83f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "3bcbd4c6-0955-4605-137b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714020,
//         "ask": 0.714080,
//         "lastTraded": null,
//         "mid": 0.714050,
//         "id": "24c30388-2fd2-4548-b844-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714170,
//         "ask": 0.714230,
//         "lastTraded": null,
//         "mid": 0.714200,
//         "id": "e3cd3b07-444b-46a7-b841-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714200,
//         "ask": 0.714260,
//         "lastTraded": null,
//         "mid": 0.714230,
//         "id": "4e339d38-895a-4ab5-b842-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "f17d7281-9f61-4e8a-b843-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "719ccf62-f7be-4241-137c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714130,
//         "ask": 0.714190,
//         "lastTraded": null,
//         "mid": 0.714160,
//         "id": "831cb4b9-41b1-46bd-b848-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714010,
//         "ask": 0.714070,
//         "lastTraded": null,
//         "mid": 0.714040,
//         "id": "32ac3f42-5392-4a08-b845-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714130,
//         "ask": 0.714190,
//         "lastTraded": null,
//         "mid": 0.714160,
//         "id": "ee744eb4-0de8-43d1-b846-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713910,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713940,
//         "id": "0f47b5bb-e9cc-440b-b847-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "874dfa24-aa3a-4534-137d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714240,
//         "ask": 0.714300,
//         "lastTraded": null,
//         "mid": 0.714270,
//         "id": "a44d3f20-709f-47b9-b84c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714140,
//         "ask": 0.714200,
//         "lastTraded": null,
//         "mid": 0.714170,
//         "id": "4567b553-87f3-4ead-b849-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714390,
//         "ask": 0.714450,
//         "lastTraded": null,
//         "mid": 0.714420,
//         "id": "7c787a33-5884-45fc-b84a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714140,
//         "ask": 0.714200,
//         "lastTraded": null,
//         "mid": 0.714170,
//         "id": "2da57424-272a-4b6c-b84b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "899cdc99-f502-46b0-137e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713880,
//         "ask": 0.713970,
//         "lastTraded": null,
//         "mid": 0.713925,
//         "id": "9f69c2a4-0067-4da0-b850-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714250,
//         "ask": 0.714310,
//         "lastTraded": null,
//         "mid": 0.714280,
//         "id": "43e0044b-e1c9-47e2-b84d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714260,
//         "ask": 0.714330,
//         "lastTraded": null,
//         "mid": 0.714295,
//         "id": "4f699dc3-650b-435c-b84e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713820,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713855,
//         "id": "fb9857bb-9374-4005-b84f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "d9fe1edf-5bd1-4e47-137f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713960,
//         "ask": 0.714020,
//         "lastTraded": null,
//         "mid": 0.713990,
//         "id": "a71cba62-3e9f-4d55-b854-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713900,
//         "ask": 0.713960,
//         "lastTraded": null,
//         "mid": 0.713930,
//         "id": "edc35d55-5a0c-4e3e-b851-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714190,
//         "ask": 0.714250,
//         "lastTraded": null,
//         "mid": 0.714220,
//         "id": "f3539945-6efd-4927-b852-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713900,
//         "ask": 0.713960,
//         "lastTraded": null,
//         "mid": 0.713930,
//         "id": "21074523-5a89-4d26-b853-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "090e2761-60bb-4e12-1380-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "a5ef20b5-239c-4bee-b858-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713950,
//         "ask": 0.714010,
//         "lastTraded": null,
//         "mid": 0.713980,
//         "id": "2e1998ee-eeba-4291-b855-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714020,
//         "ask": 0.714080,
//         "lastTraded": null,
//         "mid": 0.714050,
//         "id": "c9608a52-914c-4706-b856-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713780,
//         "ask": 0.713840,
//         "lastTraded": null,
//         "mid": 0.713810,
//         "id": "ef2b2066-b491-4a3d-b857-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "2525d9bf-c1ed-426c-1381-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713810,
//         "ask": 0.713870,
//         "lastTraded": null,
//         "mid": 0.713840,
//         "id": "ebdd68fa-abd5-4394-b85c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "61695fcc-fb18-4daa-b859-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713870,
//         "ask": 0.713930,
//         "lastTraded": null,
//         "mid": 0.713900,
//         "id": "aeefec91-672d-4f81-b85a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713650,
//         "ask": 0.713710,
//         "lastTraded": null,
//         "mid": 0.713680,
//         "id": "7cdbf887-363c-4ae9-b85b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "add3fa82-85da-4a6f-1382-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713590,
//         "ask": 0.713650,
//         "lastTraded": null,
//         "mid": 0.713620,
//         "id": "2de5294a-b17d-4022-b860-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713800,
//         "ask": 0.713860,
//         "lastTraded": null,
//         "mid": 0.713830,
//         "id": "be736d20-8933-4c11-b85d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713820,
//         "ask": 0.713890,
//         "lastTraded": null,
//         "mid": 0.713855,
//         "id": "d2e2c320-070f-4771-b85e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713540,
//         "ask": 0.713600,
//         "lastTraded": null,
//         "mid": 0.713570,
//         "id": "242c3b85-e866-4010-b85f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "96077ea3-be60-4137-1383-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.713940,
//         "ask": 0.714000,
//         "lastTraded": null,
//         "mid": 0.713970,
//         "id": "fbfd3318-a2d0-4678-b864-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713570,
//         "ask": 0.713630,
//         "lastTraded": null,
//         "mid": 0.713600,
//         "id": "9c1be057-49e6-4c64-b861-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.713970,
//         "ask": 0.714050,
//         "lastTraded": null,
//         "mid": 0.714010,
//         "id": "e4f9ea88-d01e-47a5-b862-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713520,
//         "ask": 0.713580,
//         "lastTraded": null,
//         "mid": 0.713550,
//         "id": "e3e2c87e-58e0-4d44-b863-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "65ae695d-0a44-4f9a-1384-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "6a645fc7-833b-49cd-b868-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.713970,
//         "ask": 0.714030,
//         "lastTraded": null,
//         "mid": 0.714000,
//         "id": "02c3e750-8b79-4c00-b865-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714290,
//         "ask": 0.714350,
//         "lastTraded": null,
//         "mid": 0.714320,
//         "id": "2f617188-c672-4b8d-b866-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.713850,
//         "ask": 0.713910,
//         "lastTraded": null,
//         "mid": 0.713880,
//         "id": "2ff46a83-8b93-45af-b867-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "e045b603-5bc2-4865-1385-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714550,
//         "ask": 0.714610,
//         "lastTraded": null,
//         "mid": 0.714580,
//         "id": "086a112e-ea1b-45b7-b86c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714170,
//         "ask": 0.714230,
//         "lastTraded": null,
//         "mid": 0.714200,
//         "id": "43c410a1-3156-453c-b869-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714550,
//         "ask": 0.714610,
//         "lastTraded": null,
//         "mid": 0.714580,
//         "id": "06dd5473-993e-4a7d-b86a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714170,
//         "ask": 0.714230,
//         "lastTraded": null,
//         "mid": 0.714200,
//         "id": "c1b53b63-a329-4452-b86b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "34b0a019-17fc-40e8-1386-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714650,
//         "ask": 0.714710,
//         "lastTraded": null,
//         "mid": 0.714680,
//         "id": "e3282089-2ad3-4193-b870-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714560,
//         "ask": 0.714620,
//         "lastTraded": null,
//         "mid": 0.714590,
//         "id": "78673db9-96a4-455d-b86d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714770,
//         "ask": 0.714830,
//         "lastTraded": null,
//         "mid": 0.714800,
//         "id": "0244c54a-9350-4d5a-b86e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714420,
//         "ask": 0.714480,
//         "lastTraded": null,
//         "mid": 0.714450,
//         "id": "16668ba1-c633-49f3-b86f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "3ad3d611-3f66-46c0-1387-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714560,
//         "ask": 0.714620,
//         "lastTraded": null,
//         "mid": 0.714590,
//         "id": "9162d437-33fe-47b5-b874-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714640,
//         "ask": 0.714700,
//         "lastTraded": null,
//         "mid": 0.714670,
//         "id": "d1f073d3-35a8-4194-b871-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714670,
//         "ask": 0.714730,
//         "lastTraded": null,
//         "mid": 0.714700,
//         "id": "518d172a-d7c8-456b-b872-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714490,
//         "ask": 0.714550,
//         "lastTraded": null,
//         "mid": 0.714520,
//         "id": "abcc69cd-f476-4e34-b873-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "c3041a53-30f8-40b3-1388-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "d0534921-45f0-446b-b878-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714580,
//         "ask": 0.714640,
//         "lastTraded": null,
//         "mid": 0.714610,
//         "id": "b3f8163a-4d44-4fa0-b875-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714750,
//         "ask": 0.714810,
//         "lastTraded": null,
//         "mid": 0.714780,
//         "id": "1ba3da20-52cc-4754-b876-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "60a3d46a-b4d4-43ed-b877-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "851053e3-cd01-443e-1389-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714700,
//         "ask": 0.714760,
//         "lastTraded": null,
//         "mid": 0.714730,
//         "id": "c6c75433-631c-439a-b87c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714190,
//         "ask": 0.714250,
//         "lastTraded": null,
//         "mid": 0.714220,
//         "id": "72870614-40ef-4c56-b879-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.714700,
//         "ask": 0.714760,
//         "lastTraded": null,
//         "mid": 0.714730,
//         "id": "fefbb52f-55a3-4b9a-b87a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714180,
//         "ask": 0.714240,
//         "lastTraded": null,
//         "mid": 0.714210,
//         "id": "cb4aa65a-c5f3-49fb-b87b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "3ce40840-5b9a-48ab-138a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715020,
//         "ask": 0.715080,
//         "lastTraded": null,
//         "mid": 0.715050,
//         "id": "fc4a4777-87f5-4217-b880-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714690,
//         "ask": 0.714750,
//         "lastTraded": null,
//         "mid": 0.714720,
//         "id": "a9453039-d7ea-4502-b87d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715090,
//         "ask": 0.715150,
//         "lastTraded": null,
//         "mid": 0.715120,
//         "id": "fcfcf53a-ae4a-45bd-b87e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714580,
//         "ask": 0.714640,
//         "lastTraded": null,
//         "mid": 0.714610,
//         "id": "51893295-41eb-4a21-b87f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "be89bfb8-4420-4b0f-138b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714870,
//         "ask": 0.714930,
//         "lastTraded": null,
//         "mid": 0.714900,
//         "id": "63a41914-3439-4e7b-b884-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715030,
//         "ask": 0.715090,
//         "lastTraded": null,
//         "mid": 0.715060,
//         "id": "3f289209-313b-4bc7-b881-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715090,
//         "ask": 0.715150,
//         "lastTraded": null,
//         "mid": 0.715120,
//         "id": "2572150e-1e00-42c8-b882-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714870,
//         "ask": 0.714930,
//         "lastTraded": null,
//         "mid": 0.714900,
//         "id": "51568c33-cf9f-4a92-b883-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "64ebb26a-5070-4003-138c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714920,
//         "ask": 0.714980,
//         "lastTraded": null,
//         "mid": 0.714950,
//         "id": "85a4d895-cd8a-4625-b888-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "4499dd2a-22d9-4689-b885-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715010,
//         "ask": 0.715070,
//         "lastTraded": null,
//         "mid": 0.715040,
//         "id": "b7868245-021c-40e8-b886-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "e42dc35d-fc21-4eab-b887-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "5a67155c-40f9-4955-138d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715080,
//         "ask": 0.715140,
//         "lastTraded": null,
//         "mid": 0.715110,
//         "id": "1ccf6b0a-c095-406b-b88c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714930,
//         "ask": 0.714990,
//         "lastTraded": null,
//         "mid": 0.714960,
//         "id": "7e6a648f-28c6-4d46-b889-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715080,
//         "ask": 0.715140,
//         "lastTraded": null,
//         "mid": 0.715110,
//         "id": "adcafd81-2e85-45ec-b88a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "bb88a599-6f09-48f0-b88b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "48503475-6b62-4389-138e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715110,
//         "ask": 0.715170,
//         "lastTraded": null,
//         "mid": 0.715140,
//         "id": "f0186cf7-0d43-476a-b890-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715090,
//         "ask": 0.715150,
//         "lastTraded": null,
//         "mid": 0.715120,
//         "id": "d414e48e-8489-4b5a-b88d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715240,
//         "ask": 0.715300,
//         "lastTraded": null,
//         "mid": 0.715270,
//         "id": "8a0b9b5a-7abc-44ee-b88e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714900,
//         "ask": 0.714960,
//         "lastTraded": null,
//         "mid": 0.714930,
//         "id": "0ea86e86-950f-45bb-b88f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "0cad03c2-1b6f-4079-138f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715040,
//         "ask": 0.715100,
//         "lastTraded": null,
//         "mid": 0.715070,
//         "id": "f5d7a117-6d33-453c-b894-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715120,
//         "ask": 0.715180,
//         "lastTraded": null,
//         "mid": 0.715150,
//         "id": "3c4da8d3-7309-4f9c-b891-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715340,
//         "ask": 0.715410,
//         "lastTraded": null,
//         "mid": 0.715375,
//         "id": "2766f5ff-27ae-4178-b892-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714880,
//         "ask": 0.714940,
//         "lastTraded": null,
//         "mid": 0.714910,
//         "id": "56d77f53-90b1-42c5-b893-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "249848e7-c14c-405c-1390-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714900,
//         "ask": 0.714960,
//         "lastTraded": null,
//         "mid": 0.714930,
//         "id": "985bb283-ec89-4fbc-b898-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715030,
//         "ask": 0.715090,
//         "lastTraded": null,
//         "mid": 0.715060,
//         "id": "c9d913a3-9fb8-485f-b895-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715070,
//         "ask": 0.715130,
//         "lastTraded": null,
//         "mid": 0.715100,
//         "id": "dcb5c451-cc3c-49a7-b896-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714730,
//         "ask": 0.714790,
//         "lastTraded": null,
//         "mid": 0.714760,
//         "id": "8d515a59-fcfd-489c-b897-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "42b467d5-c63a-4a81-1391-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715220,
//         "ask": 0.715280,
//         "lastTraded": null,
//         "mid": 0.715250,
//         "id": "6684cf4a-956c-4a7e-b89c-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714910,
//         "ask": 0.714970,
//         "lastTraded": null,
//         "mid": 0.714940,
//         "id": "0eb6aa42-687d-4774-b899-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715250,
//         "ask": 0.715310,
//         "lastTraded": null,
//         "mid": 0.715280,
//         "id": "a5b4a17b-22a8-437f-b89a-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714740,
//         "ask": 0.714810,
//         "lastTraded": null,
//         "mid": 0.714775,
//         "id": "00695ce5-d2cc-41c5-b89b-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "9e3cce24-b464-4bd0-1392-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715440,
//         "ask": 0.715520,
//         "lastTraded": null,
//         "mid": 0.715480,
//         "id": "5cc3e926-2bdd-4f27-b8a0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715240,
//         "ask": 0.715300,
//         "lastTraded": null,
//         "mid": 0.715270,
//         "id": "a61681c3-5758-4b8a-b89d-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715460,
//         "ask": 0.715540,
//         "lastTraded": null,
//         "mid": 0.715500,
//         "id": "5d836594-9b81-4679-b89e-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715170,
//         "ask": 0.715230,
//         "lastTraded": null,
//         "mid": 0.715200,
//         "id": "6aec07f6-3df3-4a5a-b89f-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "6cb428be-574c-4f70-1393-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715670,
//         "ask": 0.715730,
//         "lastTraded": null,
//         "mid": 0.715700,
//         "id": "98a0ab75-7b73-49fc-b8a4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715470,
//         "ask": 0.715530,
//         "lastTraded": null,
//         "mid": 0.715500,
//         "id": "7b180fde-8e36-42bc-b8a1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715750,
//         "ask": 0.715810,
//         "lastTraded": null,
//         "mid": 0.715780,
//         "id": "d35a46b2-f086-4487-b8a2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715310,
//         "ask": 0.715380,
//         "lastTraded": null,
//         "mid": 0.715345,
//         "id": "334d579a-81b2-4b82-b8a3-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "3db74914-2895-4288-1394-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714970,
//         "ask": 0.715030,
//         "lastTraded": null,
//         "mid": 0.715000,
//         "id": "314ca979-7d7c-453b-b8a8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715680,
//         "ask": 0.715740,
//         "lastTraded": null,
//         "mid": 0.715710,
//         "id": "0f16783d-5f67-4a7a-b8a5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715710,
//         "ask": 0.715780,
//         "lastTraded": null,
//         "mid": 0.715745,
//         "id": "c03eb7e5-726e-403e-b8a6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714640,
//         "ask": 0.714710,
//         "lastTraded": null,
//         "mid": 0.714675,
//         "id": "dfe9b79e-4fa0-403a-b8a7-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "97c12685-1462-438b-1395-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715110,
//         "ask": 0.715170,
//         "lastTraded": null,
//         "mid": 0.715140,
//         "id": "b1afcc65-2046-4444-b8ac-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715010,
//         "ask": 0.715070,
//         "lastTraded": null,
//         "mid": 0.715040,
//         "id": "5685e99d-163a-4ca6-b8a9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715130,
//         "ask": 0.715210,
//         "lastTraded": null,
//         "mid": 0.715170,
//         "id": "b07b733f-084b-4dac-b8aa-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714630,
//         "ask": 0.714710,
//         "lastTraded": null,
//         "mid": 0.714670,
//         "id": "12ce66af-d254-4bd6-b8ab-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "ba8b4657-652b-4543-1396-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715580,
//         "ask": 0.715640,
//         "lastTraded": null,
//         "mid": 0.715610,
//         "id": "6ee06812-d502-4e6e-b8b0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715120,
//         "ask": 0.715180,
//         "lastTraded": null,
//         "mid": 0.715150,
//         "id": "e309422a-8ee0-4cac-b8ad-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715590,
//         "ask": 0.715650,
//         "lastTraded": null,
//         "mid": 0.715620,
//         "id": "aba515d1-278f-47d2-b8ae-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715070,
//         "ask": 0.715130,
//         "lastTraded": null,
//         "mid": 0.715100,
//         "id": "5e69e548-5a3f-40e7-b8af-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "1a3a28cd-7cdf-4f57-1397-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715560,
//         "ask": 0.715620,
//         "lastTraded": null,
//         "mid": 0.715590,
//         "id": "391ee497-47ac-4c98-b8b4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715570,
//         "ask": 0.715630,
//         "lastTraded": null,
//         "mid": 0.715600,
//         "id": "3b675965-406d-49c8-b8b1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715750,
//         "ask": 0.715820,
//         "lastTraded": null,
//         "mid": 0.715785,
//         "id": "bcb981f5-3d0a-4f90-b8b2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715210,
//         "ask": 0.715290,
//         "lastTraded": null,
//         "mid": 0.715250,
//         "id": "1b884360-b8c7-4e2c-b8b3-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "3127e0e4-813b-486d-1398-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715230,
//         "ask": 0.715290,
//         "lastTraded": null,
//         "mid": 0.715260,
//         "id": "6ee65dac-1d3c-47dd-b8b8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715550,
//         "ask": 0.715610,
//         "lastTraded": null,
//         "mid": 0.715580,
//         "id": "17586645-6775-4ff7-b8b5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715700,
//         "ask": 0.715790,
//         "lastTraded": null,
//         "mid": 0.715745,
//         "id": "e7e9ae39-b05d-406f-b8b6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715210,
//         "ask": 0.715280,
//         "lastTraded": null,
//         "mid": 0.715245,
//         "id": "bd52d6f3-a046-4270-b8b7-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "92ccb084-7be7-4811-1399-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715200,
//         "ask": 0.715260,
//         "lastTraded": null,
//         "mid": 0.715230,
//         "id": "9613202b-eeb2-4455-b8bc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715240,
//         "ask": 0.715300,
//         "lastTraded": null,
//         "mid": 0.715270,
//         "id": "853fdd80-8ef8-4caa-b8b9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715360,
//         "ask": 0.715420,
//         "lastTraded": null,
//         "mid": 0.715390,
//         "id": "69f7c6b7-a74e-4ccb-b8ba-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714950,
//         "ask": 0.715010,
//         "lastTraded": null,
//         "mid": 0.714980,
//         "id": "bd2f7afe-d564-4e3d-b8bb-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "4dce7746-82e8-4f20-139a-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714930,
//         "ask": 0.714980,
//         "lastTraded": null,
//         "mid": 0.714955,
//         "id": "bdc9bc63-bfe1-4c7a-b8c0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715190,
//         "ask": 0.715250,
//         "lastTraded": null,
//         "mid": 0.715220,
//         "id": "0fb49219-683e-4810-b8bd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715440,
//         "ask": 0.715500,
//         "lastTraded": null,
//         "mid": 0.715470,
//         "id": "72745dc3-0c4f-4126-b8be-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714850,
//         "ask": 0.714920,
//         "lastTraded": null,
//         "mid": 0.714885,
//         "id": "7e98a666-db03-4016-b8bf-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "e430e7bd-ec6a-4c6f-139b-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715160,
//         "ask": 0.715240,
//         "lastTraded": null,
//         "mid": 0.715200,
//         "id": "c863ad7a-b464-4346-b8c4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714900,
//         "ask": 0.714990,
//         "lastTraded": null,
//         "mid": 0.714945,
//         "id": "4bf4a2e4-c689-491d-b8c1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715410,
//         "ask": 0.715470,
//         "lastTraded": null,
//         "mid": 0.715440,
//         "id": "4674bb17-56c8-45ba-b8c2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714830,
//         "ask": 0.714920,
//         "lastTraded": null,
//         "mid": 0.714875,
//         "id": "867eb5ad-d00f-4c73-b8c3-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "71d22bc2-4419-4eaf-139c-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715450,
//         "ask": 0.715510,
//         "lastTraded": null,
//         "mid": 0.715480,
//         "id": "c367c6a2-d976-46e7-b8c8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715190,
//         "ask": 0.715250,
//         "lastTraded": null,
//         "mid": 0.715220,
//         "id": "6ecbac44-14ab-4007-b8c5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715840,
//         "ask": 0.715900,
//         "lastTraded": null,
//         "mid": 0.715870,
//         "id": "c9a6b34a-af53-483c-b8c6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715140,
//         "ask": 0.715220,
//         "lastTraded": null,
//         "mid": 0.715180,
//         "id": "a4dda5e2-c7b1-4b18-b8c7-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "1066ed76-979c-407d-139d-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715750,
//         "ask": 0.715840,
//         "lastTraded": null,
//         "mid": 0.715795,
//         "id": "10fbe7ad-df69-4bf9-b8cc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715460,
//         "ask": 0.715520,
//         "lastTraded": null,
//         "mid": 0.715490,
//         "id": "0ed72ce1-6675-4a3a-b8c9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715860,
//         "ask": 0.715920,
//         "lastTraded": null,
//         "mid": 0.715890,
//         "id": "2b9bd85e-6d1c-4e6f-b8ca-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715350,
//         "ask": 0.715420,
//         "lastTraded": null,
//         "mid": 0.715385,
//         "id": "6a7bb05e-acf4-4444-b8cb-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "111ae5d7-ce1f-407d-139e-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.716230,
//         "ask": 0.716320,
//         "lastTraded": null,
//         "mid": 0.716275,
//         "id": "7d70ac9d-7a73-4ebb-b8d0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715760,
//         "ask": 0.715850,
//         "lastTraded": null,
//         "mid": 0.715805,
//         "id": "a520e5fa-dbb6-4f82-b8cd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.716340,
//         "ask": 0.716410,
//         "lastTraded": null,
//         "mid": 0.716375,
//         "id": "782436d0-41a4-4017-b8ce-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715580,
//         "ask": 0.715650,
//         "lastTraded": null,
//         "mid": 0.715615,
//         "id": "7c91a4a7-0dda-4895-b8cf-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "ca8ae36e-dd03-4a43-139f-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.716600,
//         "ask": 0.716660,
//         "lastTraded": null,
//         "mid": 0.716630,
//         "id": "32ed5c72-7a4b-4c3b-b8d4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.716140,
//         "ask": 0.716230,
//         "lastTraded": null,
//         "mid": 0.716185,
//         "id": "6f702a38-942c-4206-b8d1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.716600,
//         "ask": 0.716660,
//         "lastTraded": null,
//         "mid": 0.716630,
//         "id": "35f70dc9-733d-468b-b8d2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715940,
//         "ask": 0.716020,
//         "lastTraded": null,
//         "mid": 0.715980,
//         "id": "38e5fefb-85e9-42ac-b8d3-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "533dbac0-de07-4278-13a0-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.717200,
//         "ask": 0.717260,
//         "lastTraded": null,
//         "mid": 0.717230,
//         "id": "2e0bce2b-5a8f-492d-b8d8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.716590,
//         "ask": 0.716650,
//         "lastTraded": null,
//         "mid": 0.716620,
//         "id": "0b07ae81-c4a8-43f3-b8d5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.717200,
//         "ask": 0.717260,
//         "lastTraded": null,
//         "mid": 0.717230,
//         "id": "e00ae45d-3c10-4628-b8d6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.716240,
//         "ask": 0.716320,
//         "lastTraded": null,
//         "mid": 0.716280,
//         "id": "4308e642-bef3-4f11-b8d7-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "5de4a280-8e96-4ca3-13a1-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.716580,
//         "ask": 0.716670,
//         "lastTraded": null,
//         "mid": 0.716625,
//         "id": "798a9dc9-f16d-42fc-b8dc-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.717210,
//         "ask": 0.717270,
//         "lastTraded": null,
//         "mid": 0.717240,
//         "id": "4789e120-86ae-4e98-b8d9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.717210,
//         "ask": 0.717270,
//         "lastTraded": null,
//         "mid": 0.717240,
//         "id": "863baa33-f854-46cd-b8da-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.716570,
//         "ask": 0.716660,
//         "lastTraded": null,
//         "mid": 0.716615,
//         "id": "6b5ba46a-ea9d-4844-b8db-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "8c69cc55-fe1d-4776-13a2-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.716700,
//         "ask": 0.716760,
//         "lastTraded": null,
//         "mid": 0.716730,
//         "id": "30a2bee5-1ef1-4e33-b8e0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.716570,
//         "ask": 0.716660,
//         "lastTraded": null,
//         "mid": 0.716615,
//         "id": "dfcead32-1fee-452e-b8dd-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.716850,
//         "ask": 0.716940,
//         "lastTraded": null,
//         "mid": 0.716895,
//         "id": "fad95cf0-0515-4d54-b8de-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715990,
//         "ask": 0.716080,
//         "lastTraded": null,
//         "mid": 0.716035,
//         "id": "ca9cb39d-b114-49ca-b8df-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "76da4f25-967e-4678-13a3-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.714750,
//         "ask": 0.715250,
//         "lastTraded": null,
//         "mid": 0.715000,
//         "id": "c42f8a96-d9f9-4fd9-b8e4-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.716750,
//         "ask": 0.716840,
//         "lastTraded": null,
//         "mid": 0.716795,
//         "id": "c884f80c-eca5-4461-b8e1-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.717390,
//         "ask": 0.718170,
//         "lastTraded": null,
//         "mid": 0.717780,
//         "id": "2fa585e0-551a-4355-b8e2-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714750,
//         "ask": 0.715250,
//         "lastTraded": null,
//         "mid": 0.715000,
//         "id": "832cfac2-8fba-4374-b8e3-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "8b951d2d-7ba0-43e2-13a4-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715150,
//         "ask": 0.715210,
//         "lastTraded": null,
//         "mid": 0.715180,
//         "id": "33505217-21d0-4dcc-b8e8-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.714710,
//         "ask": 0.715280,
//         "lastTraded": null,
//         "mid": 0.714995,
//         "id": "fe1044e3-7509-4d47-b8e5-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715270,
//         "ask": 0.715340,
//         "lastTraded": null,
//         "mid": 0.715305,
//         "id": "b5e02fb2-0b7f-466d-b8e6-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714690,
//         "ask": 0.714930,
//         "lastTraded": null,
//         "mid": 0.714810,
//         "id": "405e1042-29e0-4fac-b8e7-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "9996de5f-80d8-4f33-13a5-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715180,
//         "ask": 0.715240,
//         "lastTraded": null,
//         "mid": 0.715210,
//         "id": "fa757660-8755-4b7d-b8ec-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715160,
//         "ask": 0.715220,
//         "lastTraded": null,
//         "mid": 0.715190,
//         "id": "4f2fd978-b428-447c-b8e9-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715270,
//         "ask": 0.715340,
//         "lastTraded": null,
//         "mid": 0.715305,
//         "id": "6473df9f-282d-41a1-b8ea-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.715000,
//         "ask": 0.715070,
//         "lastTraded": null,
//         "mid": 0.715035,
//         "id": "fdda13eb-84bf-48b2-b8eb-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": true,
//       "id": "9dcf953f-57e7-4a54-13a6-08d9e02004a6"
//     },
//     {
//       "openPrice": {
//         "bid": 0.715110,
//         "ask": 0.715200,
//         "lastTraded": null,
//         "mid": 0.715155,
//         "id": "47ec8329-4d36-4c21-b8f0-08d9e02004b3"
//       },
//       "closePrice": {
//         "bid": 0.715140,
//         "ask": 0.715200,
//         "lastTraded": null,
//         "mid": 0.715170,
//         "id": "8113509e-3091-4db7-b8ed-08d9e02004b3"
//       },
//       "highPrice": {
//         "bid": 0.715280,
//         "ask": 0.715350,
//         "lastTraded": null,
//         "mid": 0.715315,
//         "id": "6ab9cba0-459c-41bf-b8ee-08d9e02004b3"
//       },
//       "lowPrice": {
//         "bid": 0.714990,
//         "ask": 0.715050,
//         "lastTraded": null,
//         "mid": 0.715020,
//         "id": "a04e11c5-d5e5-45b0-b8ef-08d9e02004b3"
//       },
//       "movingAverage": null,
//       "isRed": false,
//       "id": "2453c13d-657a-4ec8-13a7-08d9e02004a6"
//     }
//   ],
//   "getRecent": {
//     "openPrice": {
//       "bid": 0.715110,
//       "ask": 0.715200,
//       "lastTraded": null,
//       "mid": 0.715155,
//       "id": "47ec8329-4d36-4c21-b8f0-08d9e02004b3"
//     },
//     "closePrice": {
//       "bid": 0.715140,
//       "ask": 0.715200,
//       "lastTraded": null,
//       "mid": 0.715170,
//       "id": "8113509e-3091-4db7-b8ed-08d9e02004b3"
//     },
//     "highPrice": {
//       "bid": 0.715280,
//       "ask": 0.715350,
//       "lastTraded": null,
//       "mid": 0.715315,
//       "id": "6ab9cba0-459c-41bf-b8ee-08d9e02004b3"
//     },
//     "lowPrice": {
//       "bid": 0.714990,
//       "ask": 0.715050,
//       "lastTraded": null,
//       "mid": 0.715020,
//       "id": "a04e11c5-d5e5-45b0-b8ef-08d9e02004b3"
//     },
//     "movingAverage": null,
//     "isRed": false,
//     "id": "2453c13d-657a-4ec8-13a7-08d9e02004a6"
//   },
//   "id": "e9773bd5-b856-4f18-f3fd-08d9e01fd5c2"
// }