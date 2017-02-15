import { environment } from "../environment";
import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";
import { Observable } from "rxjs";
import { Storage } from "../utilities";
import { Video } from "../video";

@Injectable()
export class ApiService {
    constructor(
        private BASE_URL:string,
        private _http: Http,
        private _storage: Storage
    ) { }

    public search(options: { query: string }) {
        return this._http
            .get(`${this._baseUrl}/api/search/get?query=${options.query}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getVideos() {
        return <Observable<Array<Video>>>this._http
            .get(`${this._baseUrl}/api/video/get`)
            .map(data => data.json());
    }
    
    public get _baseUrl() { return this.BASE_URL; }

}