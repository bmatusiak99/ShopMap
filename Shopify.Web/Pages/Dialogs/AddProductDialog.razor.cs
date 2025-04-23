using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages.Dialogs
{
    public partial class AddProductDialog : ComponentBase
    {
        [CascadingParameter] protected IMudDialogInstance MudDialog { get; set; }
        [Inject] protected IDialogService DialogService { get; set; }
        [Inject] protected IProductService ProductService { get; set; }
        [Inject] protected HttpClient Http { get; set; }

        protected MudForm _form;
        protected Models.Dtos.ProductDto _product = new();

        private ProductToAddDto productDto = new ProductToAddDto();
        protected string? _imagePreview;

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            var file = e.File;
            using var stream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(stream);
            productDto.ProductImage = stream.ToArray();

            _imagePreview = $"data:{file.ContentType};base64,{Convert.ToBase64String(productDto.ProductImage)}";
        }


        protected async Task Submit()
        {
            await _form.Validate();

            await ProductService.AddProduct(productDto);
            MudDialog.Close(DialogResult.Ok(true));
        }


        protected async Task OnValidated()
        {
            var response = await Http.PostAsJsonAsync("api/products", _product);
            if (response.IsSuccessStatusCode)
            {
                MudDialog.Close(DialogResult.Ok(_product));
            }
            else
            {
                // handle error (e.g., show snackbar or error message)
            }
        }
        protected void Cancel() => MudDialog.Cancel();

    }
}
