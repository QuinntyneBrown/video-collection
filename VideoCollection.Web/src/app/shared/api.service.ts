import { environment } from "../environment";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";

@Injectable()
export class ApiService {
    constructor(private _http: Http) { }

    public search(options: {query:string}) {
        return this._http
            .get(`${this._baseUrl}/api/search/get?query=${options.query}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            }); 
    }

    public getVideos() {
        return this._http
            .get(`${this._baseUrl}/api/video/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            }); 
    }

    public get _baseUrl() { return environment.baseUrl; }

}
