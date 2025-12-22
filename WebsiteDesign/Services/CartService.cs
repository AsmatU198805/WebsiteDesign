using Blazored.LocalStorage;
using WebsiteDesign.Components;
using WebsiteDesign.Models;
using WebsiteDesign.Services;



namespace WebsiteDesign.Services
{
    public class CartService
    {
        private const string CartKey = "cart";
        private readonly ILocalStorageService _localStorage;
        public event Action? OnCartChanged;
        public CartService (ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private void NotifyCartChanged()
        {
            OnCartChanged?.Invoke();
        }
        public async Task<List<CartItem>> GetCart()
        {
            return await _localStorage.GetItemAsync<List<CartItem>> (CartKey)
                ?? new List<CartItem> ();
        }
        public async Task<int> GetCartCount()
        {
            var cart = await GetCart();
            return cart.Sum(x => x.Quantity);
        }

        public async Task AddToCart(ProductModel product)
        {
            var Cart=await GetCart ();
            var item= Cart.FirstOrDefault(x=>x.ProductId==product.Id);

            if (item != null)
                item.Quantity++;
            else
                Cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Quantity = 1,
                    Price=product.Price
                });
            await _localStorage.SetItemAsync(CartKey, Cart);
            NotifyCartChanged();

        }

        public async Task RemoveFromCart(int ProductId)
        {
            var cart= await GetCart (); 
            cart.RemoveAll(x=>x.ProductId == ProductId);
            await _localStorage.SetItemAsync(CartKey, cart);
            NotifyCartChanged();

        }

        public async Task ClearCart()
        {
            await _localStorage.RemoveItemAsync(CartKey);
            NotifyCartChanged();
        }


    

     

      
    }
}
