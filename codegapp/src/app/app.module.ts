import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PessoaComponent } from './componentes/pessoa/pessoa.component';
import { ProjetoComponent } from './componentes/projeto/projeto.component';
import { MainComponent } from './componentes/main/main.component';
import { MenubarComponent } from './componentes/menubar/menubar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './share/material/material.module';
import { TituloComponent } from './componentes/titulo/titulo.component';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ConfirmDialogComponent } from './componentes/confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    PessoaComponent,
    ProjetoComponent,
    MainComponent,
    MenubarComponent,
    TituloComponent,
    ConfirmDialogComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
