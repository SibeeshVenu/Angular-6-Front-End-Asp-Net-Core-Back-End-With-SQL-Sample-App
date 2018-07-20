# News-App

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.6.3.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `wwwroot/` directory.

## Running lint

Run `npm run lint` to check linting errors.(https://eslint.org/).

## Running unit tests

Run `npm run test` to execute both Mocha and angular test cases [Mocha] & [Karma] (https://mochajs.org/) & (https://karma-runner.github.io) 

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## Command used to generate this project
Fornt-end Project is originally generated using Angular CLI, and backend is built in ASP.Net Core using dotnet core CLI.

## The NEWS API to be used as data source
- To get category wise news use the following end point. [Category News endpoint]
(https://newsapi.org/v2/top-headlines?category=<<news_category>>&apikey=<<api_key>>&page=1)

- To get trending news use the following endpoint. [Top Headlines endpoint]
(https://newsapi.org/v2/top-headlines?country=in&apikey=<<api_key>>&page=1)

- To search for any news based on serach text . [News search endpoint]
(https://newsapi.org/v2/everything?q=<<search_text>>&apiKey=<<api_key>>&language=en&page=1)

P.S :- You need to generate the API_KEY for the above endpoints and replace 
`<<api_key>>` with it.


## To register for an API key, follow these steps:

You need to signup to [NEWSAPI] (https://newsapi.org/register).

- After registration, API key is generated for you.
