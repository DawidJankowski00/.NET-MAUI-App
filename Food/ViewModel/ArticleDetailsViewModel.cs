using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Food.Model;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.ViewModel
{
    [QueryProperty("Article", "Article")]
    public partial class ArticleDetailsViewModel : BaseViewModel
    {
        
        public ArticleDetailsViewModel()
        {
            
        }

        [ObservableProperty]
        Article article;
    }
}