$(function () {

    var l = abp.localization.getResource('Mailing');

    var service = trait.abp.mailing.mailTasks.mailTask;
    var createModal = new abp.ModalManager(abp.appPath + 'Mailing/MailTasks/MailTask/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Mailing/MailTasks/MailTask/EditModal');

    var dataTable = $('#MailTaskTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                    return l('MailTaskDeletionConfirmationMessage', data.record.id);
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
                title: l('MailTaskTemplateId'),
                data: "templateId"
            },
            {
                title: l('MailTaskSmtpAccountId'),
                data: "smtpAccountId"
            },
            {
                title: l('MailTaskMailTo'),
                data: "mailTo"
            },
            {
                title: l('MailTaskIsActive'),
                data: "isActive"
            },
            {
                title: l('MailTaskStatus'),
                data: "status"
            },
            {
                title: l('MailTaskLogs'),
                data: "logs"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMailTaskButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
