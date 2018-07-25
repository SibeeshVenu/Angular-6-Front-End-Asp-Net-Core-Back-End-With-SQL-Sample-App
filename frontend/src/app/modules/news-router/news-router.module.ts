import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../../components/home/home.component';
import { RouterModule, Routes, Router } from '@angular/router';
import { NewsComponent } from '../../components/news/news.component';
import { Constants } from '../../constants';
import { DummyComponent } from '../../components/dummy/dummy.component';
import { FourNotFourComponent } from '../../components/four-not-four/four-not-four.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'top-headlines',
        component: NewsComponent,
        data: {
            searchType: 'news/getAll?searchType=' + Constants.UrlConstants.getTopHeadlinesNews
        }
    },
    {
        path: 'category-wise',
        component: NewsComponent,
        data: {
            searchType: 'news/getAll?searchType=' + Constants.UrlConstants.getCategoryWiseNews
        }
    },
    {
        path: 'search/:searchText',
        component: NewsComponent,
        data: {
            searchType: 'news/getAll?searchType=' + Constants.UrlConstants.search
        }
    },
    {
        path: 'DummyComponent',
        component: DummyComponent
    },
    {
        path: 'favorites',
        component: NewsComponent,
        data: {
            searchType: 'news/getFavorites'
        }
    },
    {
        path: '**',
        component: FourNotFourComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class NewsRouterModule { }
