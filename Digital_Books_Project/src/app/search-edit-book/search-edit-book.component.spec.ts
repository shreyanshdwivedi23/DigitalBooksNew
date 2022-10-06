import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchEditBookComponent } from './search-edit-book.component';

describe('SearchEditBookComponent', () => {
  let component: SearchEditBookComponent;
  let fixture: ComponentFixture<SearchEditBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchEditBookComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchEditBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
