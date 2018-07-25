export namespace Constants {
    export class UrlConstants {
        static readonly getNews = 'sources&q=artificial intelligence';
        static readonly getNewsById = 'News/:id';
        static readonly getTopHeadlinesNews = 'top-headlines&country=us&q=';
        static readonly getCategoryWiseNews = 'category-wise&country=us&q=';
        static readonly search = 'everything&q=';
        static readonly removeFromFavorites = 'News/deleteFromFavorites';
        static readonly addToFavorites = 'News/addToFavorites';
        static readonly getFavorites = 'News/getFavorites';
    }
}
