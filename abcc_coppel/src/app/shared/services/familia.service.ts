import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Familia } from '../models/familia';

@Injectable({
  providedIn: 'root'
})
export class FamiliaService {

  private _url = environment.apiUrl + "/familia";

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

  public GetAllFamilias(): Observable<Familia[]>{
    return this._http.get<Familia[]>(this._url).pipe(
      catchError(this.handleError)
    )
  }

}
