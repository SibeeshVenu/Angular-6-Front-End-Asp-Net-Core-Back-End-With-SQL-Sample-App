import { browser, by, element } from 'protractor';

export class HomePage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('app-root h1')).getText();
  }

  getTopHeadlineSection() {
    return element(by.css('headlinesSection'));
  }

  getCategoryWiseSection() {
    return element(by.css('categorySection'));
  }

  getTopHeadlineNews() {
    return element(by.css('.headlinesSection app-single-news'));
  }

  getCategoryWiseNews() {
    return element(by.css('.categorySection app-single-news'));
  }

  getCategoryDropdown() {
    return element(by.css('mat-select'));
  }

  getAllTopHeadlineNews() {
    return element.all(by.css('.headlinesSection app-single-news'));
  }

  getAllCategoryWiseNews() {
    return element.all(by.css('.categorySection app-single-news'));
  }
}
