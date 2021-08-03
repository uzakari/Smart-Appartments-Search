import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { of } from 'rxjs';
import { debounceTime, switchMap, tap } from 'rxjs/operators';
import { ServiceService } from '../core/services/service.service';
import { MarketScope, SearchResultContents } from '../shared/interfaces';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  states: any = [{
    
  }]

  loading:boolean = true;

  searchForm: FormGroup = new FormGroup({});

  searchContent: SearchResultContents[] = [];

  constructor(private formBuilder: FormBuilder, 
              private searchService: ServiceService) { }


  ngOnInit(): void {

    this.buildFileForm();

    this.getStates();

    this.getSearchResult();

  }

  buildFileForm() {
    this.searchForm = this.formBuilder.group({
      searchInput: ['', [Validators.required]],
      citySelector: ['ALL', [Validators.required]]
    });
  }

  getStates(){
    this.searchService.getMarketScope()
      .subscribe(s =>{
        this.states = s
      });
  }


  getSearchResult(){
    let multiselectValue = this.searchForm.get('citySelector')?.value;

    let cities = new Array()
    cities = multiselectValue;
    this.searchForm.get('searchInput')?.valueChanges
      .pipe(
        tap(a => console.log(a)),
        debounceTime(400),
        switchMap(searchTerm => this.searchService.getAppartmentSearch(searchTerm,cities.toString()))
      ).subscribe(sc => 
                      this.searchContent = sc.data,
                      err => console.log(err),
                      () => this.loading = false
                      )
  }

  onStateChange(){
    console.log('selected input changed');
    let searchQuery = this.searchForm.get('searchInput')?.value;

    let multiselectValue = this.searchForm.get('citySelector')?.value;

    let cities = new Array()
    cities = multiselectValue;

    if (searchQuery !== null) {
      of(searchQuery)
      .pipe(switchMap(searchTerm => this.searchService.getAppartmentSearch(searchTerm, cities.toString()))).subscribe(
        sc => this.searchContent = sc.data,
        err => console.log(err),
        () => this.loading = false
      )
    }
    else{
      console.log('form not valid yet');
    }
  }

}
