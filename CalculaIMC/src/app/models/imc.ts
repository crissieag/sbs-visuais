import { Usuario } from "./usuario";

export interface Imc {
	id?: number;
	peso?: number;
	altura?: number;
	imcUsuario?: number;
	classificacao?: number;
	usuarioid?: number;
	usuario?: Usuario;
	dataCriacao?: Date;
    usuarioNome?: string;
    usuarioNascimento?: Date;
    classificacaoFormatada?: string;
    
}
