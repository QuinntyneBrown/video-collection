﻿import { Injectable } from "@angular/core";
import { Storage } from "../utilities";
import { ApiService } from "./api.service";
import { Observable } from "rxjs";

@Injectable()
export class CurrentUserService {
    constructor(
        private _apiService: ApiService,
        private _storage: Storage
    ) {  }

    public get token() { return this._storage.get({ name: "accessToken" }); }

    public getCurrentUser(): Observable<boolean> {
        return this._apiService
            .getCurrentUser()
            .map((response: boolean | {username:string}) => {       
                const isLoggedIn = response != false;
                if (isLoggedIn) {
                    this.username = (<{ username: string }>response).username;
                }                                        
                return isLoggedIn;
            });
    }

    public username: string;
}