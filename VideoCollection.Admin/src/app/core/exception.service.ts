import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ExceptionService {

    catchBadResponse: (errorResponse: any) => Observable<any> = (errorResponse: any) => {
        const response = <Response>errorResponse;
        const responseObject = response.json();
        const errorMessage = responseObject ?
            (responseObject.error ? responseObject.error : JSON.stringify(responseObject)) :
            (response.statusText || 'unknown error');
        
        // return Observable.throw(emsg); // TODO: We should NOT swallow error here.
        return Observable.of(false);
    }
}