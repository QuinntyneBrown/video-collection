import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { User } from "./user.model";
import { Observable } from "rxjs";
import { ExceptionService } from "../core";
import { ConfigurationService } from "../configuration";

@Injectable()
export class UserService {
    constructor(
        private _configurationService: ConfigurationService,
        private _http: Http) { }

    public add(entity: User) {
        return this._http
            .post(`${this._baseUrl}/api/user/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/user/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/user/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/user/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}
