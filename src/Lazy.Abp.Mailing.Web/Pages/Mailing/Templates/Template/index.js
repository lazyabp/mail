$(function () {

    var l = abp.localization.getResource('Mailing');

    var service = trait.abp.mailing.templates.template;
    var createModal = new abp.ModalManager(abp.appPath + 'Mailing/Templates/Template/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Mailing/Templates/Template/EditModal');

    var dataTable = $('#TemplateTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('TemplateDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('TemplateName'),
                data: "name"
            },
            {
                title: l('TemplateDescription'),
                data: "description"
            },
            {
                title: l('TemplateGroupName'),
                data: "groupName"
            },
            {
                title: l('TemplateIsActive'),
                data: "isActive"
            },
            {
                title: l('TemplateTemplateContent'),
                data: "templateContent"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTemplateButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
