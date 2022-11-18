import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { HomeComponent } from './pages/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmDeleteArticuloComponent } from './shared/modals/confirm-delete-articulo/confirm-delete-articulo.component';
import { MensajeExitoComponent } from './shared/modals/mensaje-exito/mensaje-exito.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ConfirmDeleteArticuloComponent,
    MensajeExitoComponent
  ],
  imports: [
    BrowserModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    FormsModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatSnackBarModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    AppRoutingModule,
    MatDatepickerModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
