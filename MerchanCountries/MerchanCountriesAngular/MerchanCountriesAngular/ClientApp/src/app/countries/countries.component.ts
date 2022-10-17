import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-countries-data',
    templateUrl: './countries.component.html'
})
export class FetchDataComponent {
    public countries: ICountry[] = [];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<ICountry[]>(baseUrl + 'merchancountriesangular').subscribe(result => {
            this.countries = result;
        }, error => console.error(error));
    }
}

interface ICountry {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
