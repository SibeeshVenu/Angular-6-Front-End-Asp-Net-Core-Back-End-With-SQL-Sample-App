import { async, TestBed } from '@angular/core/testing';
import { Http } from '@angular/http';
import { ApiService } from './api.service';
import { Observable, defer } from 'rxjs';

describe('Api Service Tests', () => {
    let service: ApiService;
    let http: { request: jasmine.Spy };
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            providers: [Http]
        });
        http = jasmine.createSpyObj('HttpClient', ['request']);
        service = new ApiService(<any>http);
    }));
    it('Should return news -  get api', async(() => {
        const expectednews = {
            title: 'Test'
        };
        http.request.and.returnValue(new Observable<any>());
        service.get('').subscribe(news => {
            expect(news).toEqual(expectednews);
        });
        expect(http.request.calls.count()).toBe(1);
    }));
    it('Should call post api', async(() => {
        http.request.and.returnValue(new Observable<any>());
        service.post('', {}).subscribe(news => {
            expect(http.request.calls.count()).toBe(1);
        });
    }));
    it('Should call delete api', async(() => {
        http.request.and.returnValue(new Observable<any>());
        service.delete('', {}).subscribe(news => {
            expect(http.request.calls.count()).toBe(1);
        });
    }));
    it('Should call put api', async(() => {
        http.request.and.returnValue(new Observable<any>());
        service.put('', {}).subscribe(news => {
            expect(http.request.calls.count()).toBe(1);
        });
    }));
});
