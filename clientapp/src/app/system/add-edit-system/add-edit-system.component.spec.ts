import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSystemComponent } from './add-edit-system.component';

describe('AddEditSystemComponent', () => {
  let component: AddEditSystemComponent;
  let fixture: ComponentFixture<AddEditSystemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSystemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditSystemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
