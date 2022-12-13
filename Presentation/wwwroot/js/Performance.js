        $(document).ready(function () {
            var table = $('#example').DataTable({
                paging: false,
            });

            $('a.toggle-vis').on('click', function (e) {
                e.preventDefault();

                // Get the column API object
                var column = table.column($(this).attr('data-column'));

                // Toggle the visibility
                column.visible(!column.visible());
            });
        });

        $('#demoGrid').dataTable({
        });
        function ExportToExcel(type, fn, dl) {
            var elt = document.getElementById('example');

            var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
            return dl ?
                XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
                XLSX.writeFile(wb, fn || ('Performance&Report.' + (type || 'xlsx')));
        }

        function demoFromHTML() {
            var pdf = new jsPDF('l', 'mm', [620, 440]);
            source = $('#customers')[0];

            specialElementHandlers = {
                '#bypassme': function (element, renderer) {
                    return true
                }
            };
            margins = {
                top: 20,
                bottom: 15,
                left: 60,
                width: 1000
            };


            pdf.fromHTML(
                source, // HTML string or DOM elem ref.
                margins.left, // x coord
                margins.top, {// y coord
                'width': margins.width, // max width of content on PDF
                'elementHandlers': specialElementHandlers
            },
                function (dispose) {
                    pdf.save('Performance&Report.pdf');
                }
                , margins);
        }

        //function demoFromHTML() {
        //       let tableClone = $('#example');
        //              tableClone
        //              .find(".no-export")
        //              .each(function(){
        //                  $(this).hide();
        //              });
        //              //$("body").html(tableClone);
        //               html2canvas(document.getElementById('example'), {
        //          onrendered: function (canvas) {
        //              var data = canvas.toDataURL();
        //              var docDefinition = {
        //                  content: [{
        //                      image: data,
        //                      width: 500
        //                  }]
        //              };
        //              pdfMake.createPdf(docDefinition).download("Table.pdf");
        //              setTimeout(()=>{
        //              location.reload();

        //              },"1000");
        //          }
        //      });
        //  }

