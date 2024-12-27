using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using static KyubEditor.EmojiSearch.EmojiDataConversorUtility;

namespace KyubEditor.EmojiSearch
{
    public class EmojiSpriteJsonReorderTests 
    {
        [TestFixture]
        public class EmojiJsonReorderHelperTests
        {
            private const string TestData =
    @"[
    {
        ""name"": ""PHOENIX"",
        ""unified"": ""1F426-200D-1F525"",
        ""non_qualified"": null,
        ""docomo"": null,
        ""au"": null,
        ""softbank"": null,
        ""google"": null,
        ""image"": ""1f426-200d-1f525.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 34,
        ""short_name"": ""phoenix"",
        ""short_names"": [
            ""phoenix""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 646,
        ""added_in"": ""15.1"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": false,
        ""has_img_facebook"": false
    },
    {
        ""name"": ""BLACK BIRD"",
        ""unified"": ""1F426-200D-2B1B"",
        ""non_qualified"": null,
        ""docomo"": null,
        ""au"": null,
        ""softbank"": null,
        ""google"": null,
        ""image"": ""1f426-200d-2b1b.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 35,
        ""short_name"": ""black_bird"",
        ""short_names"": [
            ""black_bird""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 644,
        ""added_in"": ""15.0"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": true,
        ""has_img_facebook"": true
    },
    {
        ""name"": ""BIRD"",
        ""unified"": ""1F426"",
        ""non_qualified"": null,
        ""docomo"": ""E74F"",
        ""au"": ""E4E0"",
        ""softbank"": ""E521"",
        ""google"": ""FE1C8"",
        ""image"": ""1f426.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 36,
        ""short_name"": ""bird"",
        ""short_names"": [
            ""bird""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 631,
        ""added_in"": ""0.6"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": true,
        ""has_img_facebook"": true
    }]";

            private const string ExpectedResult =
    @"[
    {
        ""name"": ""BIRD"",
        ""unified"": ""1F426"",
        ""non_qualified"": null,
        ""docomo"": ""E74F"",
        ""au"": ""E4E0"",
        ""softbank"": ""E521"",
        ""google"": ""FE1C8"",
        ""image"": ""1f426.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 36,
        ""short_name"": ""bird"",
        ""short_names"": [
            ""bird""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 631,
        ""added_in"": ""0.6"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": true,
        ""has_img_facebook"": true
    },
    {
        ""name"": ""PHOENIX"",
        ""unified"": ""1F426-200D-1F525"",
        ""non_qualified"": null,
        ""docomo"": null,
        ""au"": null,
        ""softbank"": null,
        ""google"": null,
        ""image"": ""1f426-200d-1f525.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 34,
        ""short_name"": ""phoenix"",
        ""short_names"": [
            ""phoenix""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 646,
        ""added_in"": ""15.1"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": false,
        ""has_img_facebook"": false
    },
    {
        ""name"": ""BLACK BIRD"",
        ""unified"": ""1F426-200D-2B1B"",
        ""non_qualified"": null,
        ""docomo"": null,
        ""au"": null,
        ""softbank"": null,
        ""google"": null,
        ""image"": ""1f426-200d-2b1b.png"",
        ""sheet_x"": 11,
        ""sheet_y"": 35,
        ""short_name"": ""black_bird"",
        ""short_names"": [
            ""black_bird""
        ],
        ""text"": null,
        ""texts"": null,
        ""category"": ""Animals & Nature"",
        ""subcategory"": ""animal-bird"",
        ""sort_order"": 644,
        ""added_in"": ""15.0"",
        ""has_img_apple"": true,
        ""has_img_google"": true,
        ""has_img_twitter"": true,
        ""has_img_facebook"": true
    }]";

        [Test]
        public void ReorderJsonData_ShouldSortCorrectly()
        {
            // Arrange
            // Act
            var resultJson = EmojiDataConversorUtility.ReorderJsonData(TestData);

            var resultList = JsonConvert.DeserializeObject<List<PreConvertedImgData>>(resultJson);
            var expectedList = JsonConvert.DeserializeObject<List<PreConvertedImgData>>(ExpectedResult);

            // Assert
            Assert.AreEqual(JsonConvert.SerializeObject(resultList), JsonConvert.SerializeObject(expectedList));
        }
        }
    }
}