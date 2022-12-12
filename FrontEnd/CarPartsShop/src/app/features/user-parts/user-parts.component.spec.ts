import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPartsComponent } from './user-parts.component';

describe('UserPartsComponent', () => {
  let component: UserPartsComponent;
  let fixture: ComponentFixture<UserPartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPartsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserPartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
