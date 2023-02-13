import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSystemComponent } from './show-system.component';

describe('ShowSystemComponent', () => {
  let component: ShowSystemComponent;
  let fixture: ComponentFixture<ShowSystemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSystemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowSystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
