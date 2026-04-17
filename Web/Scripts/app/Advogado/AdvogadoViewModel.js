function AdvogadoViewModel_AoCarregarComponente() {
    AdvogadoViewModel_ConfigurarFormulario();
}

function AdvogadoViewModel_ConfigurarFormulario() {
    AdvogadoViewModel_FormatarCampos();
    AdvogadoViewModel_ConfigurarEventos();
}

function AdvogadoViewModel_ConfigurarEventos() {
    $("#Cep").on("blur", AdvogadoViewModel_AoPerderFocoCep);
}

function AdvogadoViewModel_FormatarCampos() {
    if ($.fn.mask) {
        $("#Cep").mask("00000-000");
    }

    $("#Numero").on("input", function () {
        this.value = this.value.replace(/\D/g, "");
    });
}

function AdvogadoViewModel_AoPerderFocoCep() {
    var cep = $(this).val().replace(/\D/g, "");
    var inicioRequisicao = new Date().getTime();
    var delayMinimo = 300;

    AdvogadoViewModel_LimparErroCep();

    if (cep === "") {
        AdvogadoViewModel_LimparCamposEndereco();
        AdvogadoViewModel_EsconderLoadingCep();
        return;
    }

    if (!AdvogadoViewModel_CepValido(cep)) {
        AdvogadoViewModel_LimparCamposEndereco();
        AdvogadoViewModel_EsconderLoadingCep();
        AdvogadoViewModel_MostrarErroCep("CEP inválido.");
        return;
    }

    AdvogadoViewModel_MostrarLoadingCep();

    $.ajax({
        url: "https://viacep.com.br/ws/" + cep + "/json/",
        type: "GET",
        dataType: "json",
        success: function (dados) {
            if (dados.erro) {
                AdvogadoViewModel_LimparCamposEndereco();
                AdvogadoViewModel_MostrarErroCep("CEP não encontrado.");
                return;
            }

            AdvogadoViewModel_PreencherCamposEndereco(dados);
        },
        error: function () {
            AdvogadoViewModel_LimparCamposEndereco();
            AdvogadoViewModel_MostrarErroCep("Erro ao buscar o CEP.");
        },
        complete: function () {
            var tempoDecorrido = new Date().getTime() - inicioRequisicao;
            var tempoRestante = delayMinimo - tempoDecorrido;

            if (tempoRestante > 0) {
                setTimeout(function () {
                    AdvogadoViewModel_EsconderLoadingCep();
                }, tempoRestante);
            } else {
                AdvogadoViewModel_EsconderLoadingCep();
            }
        }
    });
}

function AdvogadoViewModel_CepValido(cep) {
    if (cep.length !== 8) {
        return false;
    }

    if (AdvogadoViewModel_CepInvalidoPorPadrao(cep)) {
        return false;
    }

    return true;
}

function AdvogadoViewModel_CepInvalidoPorPadrao(cep) {
    return /^(\d)\1{7}$/.test(cep);
}

function AdvogadoViewModel_PreencherCamposEndereco(dados) {
    AdvogadoViewModel_LimparErroCep();

    $("#Logradouro").val(dados.logradouro);
    $("#Bairro").val(dados.bairro);
    $("#Estado").val(dados.uf);
    $("#Numero").focus();
}

function AdvogadoViewModel_LimparCamposEndereco() {
    $("#Logradouro").val("");
    $("#Bairro").val("");
    $("#Estado").val("");
}

function AdvogadoViewModel_MostrarErroCep(mensagem) {
    $("#Cep").addClass("is-invalid");
    $("#CepErro").html(mensagem).show();
}

function AdvogadoViewModel_LimparErroCep() {
    $("#Cep").removeClass("is-invalid");
    $("#CepErro").html("").hide();
}

function AdvogadoViewModel_MostrarLoadingCep() {
    $("#CepLoading").show();
}

function AdvogadoViewModel_EsconderLoadingCep() {
    $("#CepLoading").hide();
}