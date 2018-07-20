import { browser } from '../node_modules/protractor';
import { NewsPage } from './news.po';

describe('News Component', () => {
  let page: NewsPage;

  beforeEach(() => {
    page = new NewsPage();
  });

  it('should have news', () => {
    page.navigateTo();
    expect(page.getNews()).toBeTruthy();
  });

  it('should have more than one news', () => {
    expect(page.getAllNews().count()).toBeGreaterThan(0);
  });

  it('should add news to favorites', () => {
    expect(page.getAddToFavoriteButton()).toBeTruthy();
    page.getAddToFavoriteButton().click();
  });

  it('should have news in favorites list', () => {
    browser.get('/favorites');
    expect(page.getNews()).toBeTruthy();
    expect(page.getAllNews().count()).toBeGreaterThan(0);
  });

  it('should remove news from favorites list', () => {
    browser.get('/favorites');
    expect(page.getNews()).toBeTruthy();
    expect(page.getAllNews().count()).toBeGreaterThan(0);
    expect(page.getRemoveFromFavoriteButton()).toBeTruthy();
    page.getRemoveFromFavoriteButton().click();
  });
});
