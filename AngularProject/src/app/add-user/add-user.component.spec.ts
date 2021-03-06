import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UpdateTaskComponent } from '../update-task/update-task.component';
import { RouterTestingModule } from '@angular/router/testing';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';
import { AppComponent } from '../app.component';
import { AddTaskComponent } from '../add-task/add-task.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { Ng5SliderModule } from 'ng5-slider';
import { NgSelectModule } from '@ng-select/ng-select';
import { AddProjectComponent } from '../add-project/add-project.component';
import { AddUserComponent } from './add-user.component';
import { ViewTaskComponent } from '../view-task/view-task.component';

describe('AddUserComponent', () => {
  let component: AddUserComponent;
  let fixture: ComponentFixture<AddUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddUserComponent,
        AppComponent,
        AddTaskComponent,
        AddProjectComponent,
        ViewTaskComponent,
        UpdateTaskComponent],
        imports: [
          BrowserModule,
          AppRoutingModule,
          HttpClientModule,
          FormsModule,
          RouterTestingModule,
          RouterModule,
          MDBBootstrapModule,
          Ng5SliderModule,
          NgSelectModule
        ],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
