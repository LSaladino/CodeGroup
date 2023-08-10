import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './componentes/main/main.component';
import { PessoaComponent } from './componentes/pessoa/pessoa.component';
import { ProjetoComponent } from './componentes/projeto/projeto.component';

const routes: Routes = [
  {path:'', redirectTo:'main', pathMatch:'full'},
  {path:'main', component:MainComponent},
  {path:'pessoa', component:PessoaComponent},
  {path:'projeto', component:ProjetoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
