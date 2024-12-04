$(document).ready(function () {

    $('#Emprestimos').DataTable({
        language: 
        {
            "decimal": "",
            "emptyTable": "Não existem dados na tabela.",
            "info": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
            "infoEmpty": "Mostrando 0 até 0 de 0 entradas",
            "infoFiltered": "(filtrado por _MAX_ total de entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "Nenhum registro encontrado",
            "paginate": {
                "first": "Primeira",
                "last": "Ultima",
                "next": "Proxima",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordernar por essa coluna",
                "orderableReverse": "Inverter coluna"
            }
        }       
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 5000)
});