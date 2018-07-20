import { browser, by, element } from 'protractor';

export class NewsPage {
  navigateTo() {
    return browser.get('/top-headlines');
  }

  getNews() {
    return element(by.css('app-single-news'));
  }

  getAddToFavoriteButton() {
    return element(by.css('.btn-favorite'));
  }

  getRemoveFromFavoriteButton() {
    return element(by.css('.btn-unfavorite'));
  }

  getAllNews() {
    return element.all(by.css('app-single-news'));
  }
}
