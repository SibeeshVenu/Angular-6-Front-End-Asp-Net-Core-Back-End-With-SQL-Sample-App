import { HomePage } from './home.po';
import { browser } from '../node_modules/protractor';

describe('Home Page', () => {
  let page: HomePage;

  beforeEach(() => {
    page = new HomePage();
  });

  it('should have category wise sections', () => {
    page.navigateTo();
    expect(page.getCategoryWiseSection()).toBeTruthy();
  });

  it('should have top headline sections', () => {
    expect(page.getTopHeadlineSection()).toBeTruthy();
  });

  it('should have category wise news', () => {
    expect(page.getCategoryWiseNews()).toBeTruthy();
  });

  it('should have top headline news', () => {
    expect(page.getTopHeadlineNews()).toBeTruthy();
  });

  it('should have more than one category wise news', () => {
    expect(page.getAllCategoryWiseNews().count()).toBeGreaterThan(0);
  });

  it('should have more than one top headline news', () => {
    expect(page.getAllTopHeadlineNews().count()).toBeGreaterThan(0);
  });
});
