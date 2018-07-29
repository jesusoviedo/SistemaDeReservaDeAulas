@Code
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

@*<div class="inner-block">*@
    <!--market updates updates-->
    <div class="row" >
        <div class="col-md-4 market-update-gd">
            <div class="market-update-block clr-block-1">
                <div class="col-md-8 market-update-left">
                    <h3 id="contador"></h3>
                    <h4>Solicitudes</h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div class="market-update-right">
                    <i class="fa fa-file-text-o"> </i>
                </div>
                <div class="clearfix"> </div>
            </div>
        </div>
        <div class="col-md-4 market-update-gd">
            <div class="market-update-block clr-block-2">
                <div class="col-md-8 market-update-left">
                    <h3>135</h3>
                    <h4>Pendientes </h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div class="col-md-4 market-update-right">
                    <i class="fa fa-eye"> </i>
                </div>
                <div class="clearfix"> </div>
            </div>
        </div>
        <div class="col-md-4 market-update-gd">
            <div class="market-update-block clr-block-3">
                <div class="col-md-8 market-update-left">
                    <h3>23</h3>
                    <h4>Aprobados</h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div class="col-md-4 market-update-right">
                    <i class="fa fa-envelope-o"> </i>
                </div>
                <div class="clearfix"> </div>
            </div>
        </div>
        <div class="clearfix"> </div>
    </div>
@*</div>*@


<script type="text/javascript">
    var cont = 0;

    function func(){
	    cont++;
	    document.getElementById("contador").innerHTML = cont;
    }

    window.onload = function () {
        setInterval('func()', 1000);
    }

</script>