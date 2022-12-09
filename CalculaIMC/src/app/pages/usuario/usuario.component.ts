import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Usuario } from "src/app/models/usuario";

@Component({
	selector: "app-usuario",
	templateUrl: "./usuario.component.html",
	styleUrls: ["./usuario.component.css"],
})
export class UsuarioComponent implements OnInit {
	constructor(private http: HttpClient, private router: Router) {}

	id?: number;
	nome?: string;
	nascimento?: Date;
	usuarios!: Usuario[];

	ngOnInit(): void {
		this.http
			.get<Usuario[]>("https://localhost:5001/api/usuarios/listar")
			.subscribe({
				next: (usuarios) => {
					this.usuarios = usuarios;
				},
			});
	}

	cadastrar(): void {
		// montando o json
		let usuario: Usuario = {
			id: this.id,
			nome: this.nome,
			nascimento: this.nascimento,
		};

		this.http
			.post<Usuario>("https://localhost:5001/api/usuarios/cadastrar", usuario)
			.subscribe({ next: (usuario) => this.usuarios.push(usuario) });
	}
}
