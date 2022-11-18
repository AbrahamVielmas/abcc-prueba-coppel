import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Articulo } from '../models/articulo';

@Injectable({
  providedIn: 'root'
})
export class ArticuloService {

  private _url = environment.apiUrl + "/articulo";

  constructor(
    private _http: HttpClient
  ) { }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  public GetArticuloBySku(sku: number): Observable<Articulo>{
    const url = `${this._url}/${sku}`;
    return this._http.get<Articulo>(url).pipe(
      catchError(this.handleError)
    );
  }

  public DeleteArticulo(sku: number): Observable<number>{
    const url = `${this._url}/${sku}`;
    return this._http.delete<number>(url).pipe(
      catchError(this.handleError)
    )
  }

  public UpdateArticulo(art: Articulo): Observable<Articulo>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }
    const body = JSON.stringify(art);
    return this._http.put<Articulo>(this._url, body, httpOptions).pipe(
      catchError(this.handleError)
    )
  }

  public CreateArticulo(art: Articulo): Observable<Articulo>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }
    const body = JSON.stringify(art);
    return this._http.post<Articulo>(this._url, body, httpOptions).pipe(
      catchError(this.handleError)
    )
  }

}
