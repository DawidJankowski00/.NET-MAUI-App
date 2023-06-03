using Food.Model;
using System.Collections.ObjectModel;
using Food.Services;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using Food.Pages;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Food.ViewModel
{
    public partial class ArticleViewModel : BaseViewModel
    {
        ArticleService articleService;
        public ObservableCollection<Article> Articles { get; } = new();

        IConnectivity connectivity;
        public ArticleViewModel(ArticleService articleService, IConnectivity connectivity)
        {
            Title = "Articles";
            this.articleService = articleService;
            this.connectivity = connectivity;
            _ = GetArticleAsync();
        }

        [RelayCommand]
        async Task GoToDetailAsync(Article article)
        {
            try
            {
                if (article is null) { return; }

                await Shell.Current.GoToAsync($"{nameof(ArticleDetailsPage)}", true,
                    new Dictionary<string, object>
                    {
                    {"Article",article }
                    });
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get products: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        async Task GetArticleAsync()
        {
            if (IsBusy) { return; }
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Brak połączenia z internetem!", $"Sprawdź polaczenie internetowe i spróbuj ponownie ", "OK");
                    return;
                }

                IsBusy = true;
                var articles = await articleService.GetProducts();

                if (Articles.Count != 0)
                {
                    Articles.Clear();
                }
                foreach (Article article in articles)
                {
                    Articles.Add(article);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get products: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
