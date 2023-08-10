import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from 'src/app/Models/Pessoa';
import { Projeto } from 'src/app/Models/Projeto';
import { PessoaService } from 'src/app/services/pessoa.service';
import { ProjetoService } from 'src/app/services/projeto.service';
import { DialogService } from 'src/app/share/dialog.service';

@Component({
  selector: 'app-projeto',
  templateUrl: './projeto.component.html',
  styleUrls: ['./projeto.component.css']
})
export class ProjetoComponent implements OnInit {

  ngOnInit() {
    this.carregarProjetos();
  }

  constructor(private projetoService: ProjetoService,
    private fb: FormBuilder,
    private dialogService: DialogService,
    private servicePessoa: PessoaService) {

    this.CreateFormProjeto();
    this.PreencheListaGerentes();

  }

  public frmProjeto!: FormGroup;
  public p_submitted!: boolean;
  public p_titulo_projeto = 'Cadastro de Projetos';
  public oProjetos: Projeto[] = [];
  public oProjeto!: Projeto;
  public projetoSelecionado!: Projeto;
  public statusMode: string = '';
  public newProjeto: Projeto = new Projeto;
  public listagemGerentes?: Pessoa[];
  public selectedGerentes!: any;
  public isUpdateMode: boolean = false;
  // ------------------------------------------

  CreateFormProjeto() {

    this.frmProjeto = this.fb.group({
      projetoId: [''],
      nome: ['', [Validators.required, Validators.minLength(10)]],
      dataInicio: ['', [Validators.required]],
      dataPrevisaoFim: ['', [Validators.required]],
      dataFim: ['', [Validators.required]],
      descricao: ['', [Validators.required, Validators.minLength(15)]],
      status: ['', [Validators.required, Validators.minLength(5)]],
      orcamento: ['', [Validators.required]],
      risco: ['', [Validators.required]],
      pessoaId: ['', [Validators.required]]
    })

  }

  EnviaProjeto() {
    this.p_submitted = true;

    this.frmProjeto.value.pessoaId = this.selectedGerentes.pessoaId;
    this.frmProjeto.value.orcamento = parseFloat(this.frmProjeto.value.orcamento);

    (this.projetoSelecionado?.projetoId != 0) ? this.statusMode = 'put' : this.statusMode = 'post';

    if (this.statusMode == 'put') {

      if (typeof this.frmProjeto.value.projetoId === "undefined") {
        this.frmProjeto.value.pessoaId = this.projetoSelecionado.projetoId;
      }

      this.atualizaProjeto(this.frmProjeto.value);
      this.Voltar();
    }

    if (this.statusMode == 'post') {

      this.newProjeto = this.frmProjeto.value;
      this.CreateNewProjetoPrepare(this.frmProjeto.value);
      this.Voltar();
    }

    this.ResetForm();

  }

  projetoNovo() {
    this.ResetForm();
    this.projetoSelecionado = new Projeto();
    this.frmProjeto.patchValue(this.projetoSelecionado);
    this.PreencheListaGerentes();
  }


  atualizaProjeto(projetoUpd: Projeto) {
    this.projetoService.UpdateProjeto(projetoUpd).subscribe({
      next: (projeto: Projeto) => {
        console.log(projeto)
        this.carregarProjetos();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  Voltar() {
    this.projetoSelecionado = this.oProjeto;
  }

  CreateNewProjetoPrepare(projeto: Projeto) {
    this.projetoService.CreateNewProjeto(projeto).subscribe({
      next: (newCustomer = projeto) => {
        this.carregarProjetos();
      },
      error: (err) => {
        console.log('Found errors: ' + err);
      }
    })
  }

  carregarProjetos(): void {
    this.projetoService.GetAllProjetos().subscribe({
      next: (projetos: Projeto[]) => {
        this.oProjetos = projetos;
        // console.log(projetos);
      },
      error: (err) => {
        console.log('somethings wrong occurred: ' + err);
      }
    });
  }

  projetoSelected(projeto: Projeto) {
    this.projetoSelecionado = projeto;
    if (this.projetoSelecionado.pessoaId != null) {
      this.BuscaGerente()
    }
    // this.isUpdateMode = true;
    this.frmProjeto.patchValue(projeto);
  }

  projetoExcluir(projetoForm: Projeto) {
    this.dialogService.confirmDialog({
      title: 'EXCLUSÃO DE DADOS',
      message: `Confirma a exclusão do Projeto: ${projetoForm.nome} ?`,
      confirmText: 'Sim',
      cancelText: 'Não',
    },).subscribe(res => {
      if (res) {
        this.projetoService.RemoveProjeto(projetoForm.projetoId).subscribe({
          next: () => {
            // this.toastr.info('Registro excluído com sucesso !', 'EXCLUSÃO DE DADOS');
            this.carregarProjetos();
          },
          error: (err) => {
            console.log(err);
          }
        })
      }

    })
  }//end method

  LimpaProjetoForms() {
    this.frmProjeto.reset(new Projeto());
  }

  ResetForm(): void {
    this.frmProjeto.reset();
  }

  PreencheListaGerentes() {
    this.servicePessoa.GetAllPessoaTwoFields().subscribe({
      next: (listGerentes: Pessoa[]) => {
        this.listagemGerentes = listGerentes;
      },
      error: () => {
        console.log("Deu Ruim....rsrsrs")
      }
    })
  }


  // BuscaGerente(gerenteId: number) {
  //   this.servicePessoa.GetAllPessoaTwoFieldsById(gerenteId).subscribe({
  //     next: (gerente: Pessoa) => {
  //       this.listagemGerentesOne = gerente;
  //       console.log(this.isUpdateMode);
  //       console.log(this.listagemGerentesOne);
  //     },
  //     error: () => {

  //     }
  //   })
  // }

  BuscaGerente() {
    this.servicePessoa.GetAllPessoaTwoFields().subscribe({
      next: (listGerentes: Pessoa[]) => {
        this.listagemGerentes = listGerentes.filter(g => g.pessoaId === this.frmProjeto.value.pessoaId);
      },
      error: () => {
        console.log("Deu Ruim....rsrsrs")
      }
    })
  }

}
