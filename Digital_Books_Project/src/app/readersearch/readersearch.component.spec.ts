import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadersearchComponent } from './readersearch.component';

describe('ReadersearchComponent', () => {
  let component: ReadersearchComponent;
  let fixture: ComponentFixture<ReadersearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReadersearchComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReadersearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
