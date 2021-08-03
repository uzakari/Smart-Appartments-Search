import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MarketScope, SearchResult, SearchResultContents } from 'src/app/shared/interfaces';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http: HttpClient) { }


  getMarketScope(): Observable<MarketScope[]> {
    return this.http.get<MarketScope[]>(`${environment.ExternalService.FileService.baseUrl}api/Search/market`)
        .pipe(
            tap(c => console.log(c)),
            catchError(this.handleError)
        );
  }


  getAppartmentSearch(searchquery:string, scope:string): Observable<SearchResult> {
    return this.http.get<SearchResult>(`${environment.ExternalService.FileService.baseUrl}api/search?searchQuery=${searchquery}&scope=${scope}`)
        .pipe(
            tap(c => console.log(c)),
            map(a => ({
                ...a,
                data: a.data?.length > 0? a.data : []
            } as  SearchResult)),
            tap(n => console.log(n)),
            catchError(this.handleError)
        );
  }


  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
        const errMessage = error.error.message;
        return Observable.throw(errMessage);
        // Use the following instead if using lite-server
        // return Observable.throw(err.text() || 'backend server error');
    }
    return Observable.throw(error || 'server error');
}
}
