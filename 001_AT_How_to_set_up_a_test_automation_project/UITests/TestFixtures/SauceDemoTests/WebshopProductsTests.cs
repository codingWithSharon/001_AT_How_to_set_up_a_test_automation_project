using _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagesSetup;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.SauceDemoTests
{
    [TestFixture, Order(2)]
    [Parallelizable(ParallelScope.None)]
    public class WebshopProductsTests : Setup
    {
        [Test, Order(1), Retry(2)]
        public async Task SelectAddAndCheckout()
        {
            await loginSauceDemoPage.GoToLoginSauceDemoPage();
            await loginSauceDemoPage.EnterUsername("standard_user");
            await loginSauceDemoPage.EnterPassword("secret_sauce");
            await loginSauceDemoPage.ClickLoginButton();
            await Expect(webshopProductsSauceDemoPage.SelectItemTitle(1)).ToHaveTextAsync("Sauce Labs Backpack");
            await Expect(webshopProductsSauceDemoPage.SelectItemDescription(1)).ToHaveTextAsync("carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.");
            await Expect(webshopProductsSauceDemoPage.SelectItemPrice(1)).ToHaveTextAsync("$29.99");
            await webshopProductsSauceDemoPage.SelectAddItemToCart(1);
            await Expect(webshopProductsSauceDemoPage.SelectButtonRemoveFromCart(1)).ToHaveTextAsync("Remove");
            await webshopProductsSauceDemoPage.ClickShoppingCartButton();
            await Expect(webshopProductsSauceDemoPage._headerShoppingCart).ToBeVisibleAsync();
            await webshopProductsSauceDemoPage.ClickContinueShoppingButton();
            await Expect(webshopProductsSauceDemoPage._headereWebshop).ToBeVisibleAsync();
            await webshopProductsSauceDemoPage.ClickShoppingCartButton();
            await Expect(webshopProductsSauceDemoPage._containerQuantity).ToHaveTextAsync("1");
            await webshopProductsSauceDemoPage.ClickCheckoutButton();
            await webshopProductsSauceDemoPage.EnterFirstNameForCheckout("John");
            await webshopProductsSauceDemoPage.EnterLastNameForCheckout("Doe");
            await webshopProductsSauceDemoPage.EnterPostalCodeForCheckout("12345");
            await webshopProductsSauceDemoPage.ClickContinueButton();
            await Expect(webshopProductsSauceDemoPage._itemTotalPrice).ToHaveTextAsync("Item total: $29.99");
            await Expect(webshopProductsSauceDemoPage._itemTax).ToHaveTextAsync("Tax: $2.40");
            await Expect(webshopProductsSauceDemoPage._itemTotalWithTax).ToHaveTextAsync("Total: $32.39");
            await webshopProductsSauceDemoPage.ClickFinishButton();
            await Expect(webshopProductsSauceDemoPage._headerCheckoutSucceeded).ToBeVisibleAsync();
            Console.WriteLine("""   
                    Selecteing items from the webshop, adding to cart, checking out, and verifying the order completion was successful.
                    """);
        }
    }
}
