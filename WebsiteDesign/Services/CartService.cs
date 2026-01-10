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

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private void NotifyCartChanged()
        {
            OnCartChanged?.Invoke();
        }

    
        public async Task<List<CartItem>> GetCart()
        {
            try
            {
                return await _localStorage.GetItemAsync<List<CartItem>>(CartKey)
                       ?? new List<CartItem>();
            }
            catch (InvalidOperationException)
            {
                
                return new List<CartItem>();
            }
        }

        // ✅ SAFE cart count
        public async Task<int> GetCartCount()
        {
            var cart = await GetCart();
            return cart.Sum(x => x.Quantity);
        }

        // ✅ API-based product
        public async Task AddToCart(Product product)
        {
            var cart = await GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Name = product.ProductName,
                    Image = product.ImageUrl,
                    Quantity = 1,
                    Price = product.Price
                });
            }

            await SafeSetCart(cart);
            NotifyCartChanged();
        }

        public async Task RemoveFromCart(int productId)
        {
            var cart = await GetCart();
            cart.RemoveAll(x => x.ProductId == productId);

            await SafeSetCart(cart);
            NotifyCartChanged();
        }

        public async Task ClearCart()
        {
            try
            {
                await _localStorage.RemoveItemAsync(CartKey);
                NotifyCartChanged();
            }
            catch (InvalidOperationException)
            {
                // prerender safe
            }
        }

        // 🔒 JS-safe setter
        private async Task SafeSetCart(List<CartItem> cart)
        {
            try
            {
                await _localStorage.SetItemAsync(CartKey, cart);
            }
            catch (InvalidOperationException)
            {
                // JS not ready yet
            }
        }
    }
}