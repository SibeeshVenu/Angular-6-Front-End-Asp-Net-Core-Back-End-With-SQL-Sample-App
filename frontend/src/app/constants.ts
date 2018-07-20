export namespace Constants {
    export class UrlConstants {
        static readonly getNews = 'sources&q=artificial intelligence';
        static readonly getNewsById = 'News/:id';
        static readonly getTopHeadlinesNews = 'top-headlines&country=us&q=';
        static readonly getCategoryWiseNews = 'category-wise&country=us&q=';
        static readonly search = 'sources&q=';
        static readonly removeFromFavorites = 'News/deleteFromFavorites';
        static readonly addToFavorites = 'News/addToFavorites';
        static readonly getFavorites = 'News/getFavorites';
        static readonly thumbnailUrl = 'w185_and_h278_bestv2';
        static readonly singleImglUrl = 'w600_and_h900_bestv2';
        static readonly register = 'register';
        static readonly login = 'login';
    }
    export class Validation {
        static readonly invalid = 'Invalid form';
        static readonly loginError = 'Invalid login';
        static readonly registerError = 'Something happened, please check later';
    }
    export class Common {
        static readonly tokenKey = 'tokenKey';
        static readonly loggedInUserId = 'loggedInUserId';
        static readonly searchStorageKey = 'searchStorageKey';
    }
}
