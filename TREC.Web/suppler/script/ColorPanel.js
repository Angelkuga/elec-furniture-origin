function $$(id) {
    return document.getElementById(id);
}
function ColorPanel() {
    this.fill = "000000";
    this.size = 5;
    this.cellsize = 15;
    this.R = null;
    this.G = null;
    this.B = null;
    this.C = null;

    var _this = this;
    var _colorPanel;
    var _colorDis = document.createElement("div");

    this._convertor = function (val) {
        var v = parseInt("0x" + val);
        return isNaN(v) ? 0 : v;
    }
    this._format = function (val) {
        val = val == null ? "000000" : val;
        val = val.replace("#", "");
        if (val.length < 6) {
            if (val.length == 3) {
                var c0 = val.substr(0, 1);
                var c1 = val.substr(1, 1);
                var c2 = val.substr(2, 1);
                val = c0 + c0 + c1 + c1 + c2 + c2;
            }
            else {
                val = val + this.fill.substr(val.length);
            }
        }
        else {
            val = val.substr(0, 6);
        }
        return [val.substr(0, 2), val.substr(2, 2), val.substr(4, 2)];
    }
    this.$$ = function (val) {
        var ff = this._format(val);
        return [this._convertor(ff[0]), this._convertor(ff[1]), this._convertor(ff[2])]
    }
    //rgb to 16bit color
    this._unconvert = function (val) {
        if (!isNaN(parseInt(val))) {
            val = (parseInt(val) % 256).toString(16) + "";
            if (val.length < 2) val = "0" + val;
            return val;
        } else {
            return "ff";
        }
    }
    this.c16 = function (r, g, b) {
        return "#" + this._unconvert(r) + this._unconvert(g) + this._unconvert(b)
    }
    //
    this.panel = function () {
        var step = 255 / this.size;
        var div = document.createElement("div");
        div.style.cssText = "width:" + this.cellsize * ((this.size + 1) * parseInt((this.size + 1) / 2) + 1) + "px; height:" + this.cellsize * (this.size + 1) * 2 + "px; border-left:1px solid #000; border-top:1px solid #000; background-color:#ccc; position:absolute; margin-top:1px;";
        div.style.display = "none";
        div.appendChild(this.graypanel());
        for (var ir = 0; ir < 256; ir += step) {
            var r = document.createElement("div");
            r.style.cssText = "width:" + this.cellsize * (this.size + 1) + "px; float:left;";
            for (var ig = 0; ig < 256; ig += step) {
                for (var ib = 0; ib < 256; ib += step) {
                    r.appendChild(this._cell(ir, ig, ib));
                }
            }
            div.appendChild(r);
        }
        return div;
    }
    this.init = function (container, C) {
        this.C = C;
        var div = document.createElement("div");
        var but = document.createElement("div");
        _colorPanel = this.panel();
        _colorDis.style.cssText = "width:20px; border:1px solid #000; font-size:12px; text-align:center; padding:5px; cursor:pointer; height:15px;";
        this._presetColor();
        _colorDis.title = "Click here to pick color";


        div.appendChild(_colorDis);
        div.appendChild(_colorPanel);

        but.innerHTML = "Change Color";
        but.style.cssText = "width:100px; border:1px solid #000; font-size:12px; text-align:center; padding:5px; cursor:pointer; float:left; height:15px; font-family:Verdana, Arial, Helvetica, sans-serif;";
        div.onclick = function () {
            if (_colorPanel.style.display != "none") {
                _colorPanel.style.display = "none";
            } else {
                _colorPanel.style.display = "block";
            }
            _this._presetColor();
        }
        container.appendChild(div);
    }
    this._presetColor = function () {
        if (_this.R != null && _this.G != null && _this.B != null) {
            _colorDis.style.backgroundColor = this.c16(_this.R.value, _this.G.value, _this.B.value);
        }
        //_colorPanel.style.display = "none";
    }
    this._cell = function (r, g, b) {
        var div = document.createElement("div");
        div.title = this.c16(r, g, b);
        div.color = this.c16(r, g, b);
        div.style.cssText = "border:1px solid #000; border-top:0px; border-left:0px; width:" + (this.cellsize - 1) + "px; height:" + (this.cellsize - 1) + "px; float:left; overflow:hidden; cursor:pointer; background-color:" + this.c16(r, g, b);
        div.onclick = function () {
            if (_this.R != null) _this.R.value = parseInt(r);
            if (_this.G != null) _this.G.value = parseInt(g);
            if (_this.B != null) _this.B.value = parseInt(b);
            if (_this.C != null) _this.C.value = div.title;
            _this._presetColor();
        }
        div.onmouseover = function () {
            this.style.cssText = "border:1px solid #fff; width:" + (_this.cellsize - 2) + "px; height:" + (_this.cellsize - 2) + "px; float:left; overflow:hidden; cursor:pointer; background-color:" + _this.c16(r, g, b);
            _colorDis.style.backgroundColor = this.color;
        }
        div.onmouseout = function () {
            this.style.cssText = "border:1px solid #000; border-top:0px; border-left:0px; width:" + (_this.cellsize - 1) + "px; height:" + (_this.cellsize - 1) + "px; float:left; overflow:hidden; cursor:pointer; background-color:" + _this.c16(r, g, b);
        }
        return div
    }
    this.graypanel = function () {
        var step = parseInt(255 / (this.size * 2 + 1));
        var div = document.createElement("div");
        div.style.cssText = "width:" + this.cellsize + "px; height:" + this.cellsize * (this.size + 1) * 2 + "px; float:left";
        for (var i = 0; i < 256; i += step) {
            if (256 - i < step) i = 255
            div.appendChild(this._cell(i, i, i));
        }
        return div;
    }
}