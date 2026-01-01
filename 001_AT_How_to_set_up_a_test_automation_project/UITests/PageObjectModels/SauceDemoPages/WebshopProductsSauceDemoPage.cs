using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.PageObjectModels.SauceDemoPages
{
    public class WebshopProductsSauceDemoPage : BasePage
    {
        public WebshopProductsSauceDemoPage(IPage page) : base(page) { }

        #region general
        public ILocator _headereWebshop => Page.Locator("xpath=//*[@class='header_secondary_container']");
        public ILocator _inventoryItemContainer => Page.Locator("xpath=//*[@class='inventory_item']");
        public ILocator SelectInventoryItem(int item) { return Page.Locator($"xpath=(//*[@class='inventory_item'])[{item}]"); }
        #endregion

        #region items
        public ILocator SelectButtonAddToCart(int add) { return Page.Locator($"xpath=(//*[@class='btn btn_primary btn_small btn_inventory '])[{add}]"); }
        public ILocator SelectButtonRemoveFromCart(int remove) { return Page.Locator($"xpath=(//*[@class='btn btn_secondary btn_small btn_inventory '])[{remove}]"); }
        public ILocator SelectItemTitle(int title) { return Page.Locator($"xpath=(//*[@class='inventory_item_name '])[{title}]"); }
        public ILocator SelectItemDescription(int description) { return Page.Locator($"xpath=(//*[@class='inventory_item_desc'])[{description}]"); }
        public ILocator SelectItemPrice(int price) { return Page.Locator($"xpath=(//*[@class='inventory_item_price'])[{price}]"); }
        #endregion

        #region shoppingcart
        public ILocator _buttonShoppingCart => Page.Locator("#shopping_cart_container");
        public ILocator _headerShoppingCart => Page.Locator("xpath=//*[@class='title']");
        public ILocator _containerQuantity => Page.Locator("xpath=//*[@class='cart_quantity']");
        public ILocator _buttonContinueShopping => Page.Locator("xpath=//*[@class='btn btn_secondary back btn_medium']");
        public ILocator _buttonCheckout => Page.Locator("xpath=//*[@class='btn btn_action btn_medium checkout_button ']");
        #endregion

        #region checkout
        public ILocator SelectInputfieldForCheckout(int input) { return Page.Locator($"xpath=(//*[@class='input_error form_input'])[{input}]"); }
        public ILocator _buttonCancel => Page.Locator("xpath=//*[@class='btn btn_secondary back btn_medium cart_cancel_link']");
        public ILocator _buttonFinish => Page.Locator("xpath=//*[@class='btn btn_action btn_medium cart_button']");
        public ILocator _buttonContinue => Page.Locator("xpath=//*[@class='submit-button btn btn_primary cart_button btn_action']");
        public ILocator _itemTotalPrice => Page.Locator("xpath=//*[@class='summary_subtotal_label']");
        public ILocator _itemTax => Page.Locator("xpath=//*[@class='summary_tax_label']");
        public ILocator _itemTotalWithTax => Page.Locator("xpath=//*[@class='summary_total_label']");
        public ILocator _headerCheckoutSucceeded => Page.Locator("xpath=//*[@class='complete-header']");
        public ILocator _buttonGoBackHome => Page.Locator("xpath=//*[@class='btn btn_primary btn_small']");
        #endregion


        #region basic operations login page

        #region genral and items
        public async Task SelectAnInventoryItem(int item)
        {
            await SelectInventoryItem(item).ClickAsync();
        }

        public async Task SelectAddItemToCart(int button)
        {
            await SelectButtonAddToCart(button).ClickAsync();
        }

        public async Task SelectAnItemTitleLink(int title)
        {
            await SelectItemTitle(title).ClickAsync();
        }
        #endregion

        #region shoppingcart
        public async Task ClickShoppingCartButton()
        {
            await _buttonShoppingCart.ClickAsync();
        }

        public async Task ClickContinueShoppingButton()
        {
            await _buttonContinueShopping.ClickAsync();
        }
        public async Task ClickCheckoutButton()
        {
            await _buttonCheckout.ClickAsync();
        }
        #endregion

        #region checkout
        public async Task EnterFirstNameForCheckout(string firstName)
        {
            await SelectInputfieldForCheckout(1).FillAsync(firstName);
        }
        public async Task EnterLastNameForCheckout(string lastName)
        {
            await SelectInputfieldForCheckout(2).FillAsync(lastName);
        }
        public async Task EnterPostalCodeForCheckout(string postalCode)
        {
            await SelectInputfieldForCheckout(3).FillAsync(postalCode);
        }
        public async Task ClickCancelButton()
        {
            await _buttonCancel.ClickAsync();
        }
        public async Task ClickFinishButton()
        {
            await _buttonFinish.ClickAsync();
        }
        public async Task ClickContinueButton()
        {
            await _buttonContinue.ClickAsync();
        }
        public async Task ClickGoBackHomeButton()
        {
            await _buttonGoBackHome.ClickAsync();
        }
        #endregion

        #endregion

    }
}
