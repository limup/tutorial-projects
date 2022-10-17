import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from "src/app/models/country";

@Component({
    selector: 'app-countries-data',
    templateUrl: './countries.component.html'
})
export class CountriesComponent {
    public countries: Country[] = [];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<Country[]>(baseUrl + 'merchancountriesangular').subscribe(result => {
            this.countries = result;
        }, error => console.error(error));
    }
}
