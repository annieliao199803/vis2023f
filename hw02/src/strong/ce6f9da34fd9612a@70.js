function _1(md){return(
md`# HW2 Strong baseline`
)}

function _data(FileAttachment){return(
FileAttachment("data.json").json()
)}

function _yCounts(){return(
[]
)}

function _constellations(data){return(
data.map(item => item.Constellation)
)}

function _cons(){return(
['牡羊座','金牛座','雙子座','巨蟹座','獅子座','處女座','天秤座','天蠍座','射手座','摩羯座','水瓶座','雙魚座']
)}

function _6(yCounts,constellations,cons,data)
{
  yCounts.length = 0; //將yCounts清空
  var minConstellation = Math.min(...constellations); //最早出生年
  var maxConstellation = Math.max(...constellations); //最晚出生年
  for (var y=minConstellation; y<=maxConstellation; y++) { 
    yCounts.push({constellation:cons[y], gender:"male", count:0}); 
    yCounts.push({constellation:cons[y], gender:"female", count:0}); 
    
    
    // //所有年份都建立兩個Object，一個存放男性資料，一個存放女性資料
    // yCounts.push({constellation:y, gender:"male", count:0}); 
    // //Object包含：1. 出生年，2.男性，3.人數(設為0)
    // yCounts.push({constellation:y, gender:"female", count:0}); 
    // //Object包含：1. 出生年，2.女性，3.人數(設為0)
  }
  data.forEach (x=> {
    var i = (x.Constellation-minConstellation)*2 + (x.Gender== "男" ? 0 : 1); 
    yCounts[i].count++;
    //讀取data array，加總每個年份出生的人
  })
  return yCounts
}


function _plot2(Inputs){return(
Inputs.form({
	mt:  Inputs.range([0, 100], {label: "marginTop", step: 1}),
	mr:  Inputs.range([0, 100], {label: "marginRight", step: 1}),
	mb:  Inputs.range([0, 100], {label: "marginBottom", step: 1}),
	ml:  Inputs.range([0, 100], {label: "marginLeft", step: 1}),
})
)}

function _8(md){return(
md`# Strong baseline 1 `
)}

function _9(Plot,plot2,yCounts){return(
Plot.plot({
  marginTop: plot2.mt,
  marginRight: plot2.mr,
  marginBottom: plot2.mb,
  marginLeft: plot2.ml,
  
  grid: true,
  y: {label: "count"},
  marks: [
    Plot.ruleY([0]),
    Plot.barY(yCounts, {x: "constellation", y: "count", tip: true , fill:"gender"}),
  ]
})
)}

function _10(md){return(
md`# Strong baseline 2`
)}

function _11(Plot,plot2,cons,data){return(
Plot.plot({
  marginTop: plot2.mt,
  marginRight: plot2.mr,
  marginBottom: plot2.mb,
  marginLeft: plot2.ml,
  grid: true,
  y: {label: "count"},
  x: {
    ticks: 12,
    tickFormat: index => cons[index],
    domain:[0, 12]
  },
  marks: [
    Plot.ruleY([0]),
    Plot.rectY(data, Plot.binX({y:"Count"}, {x: "Constellation", tip: true , fill:"Gender", interval : 1})),
  ],
})
)}

export default function define(runtime, observer) {
  const main = runtime.module();
  function toString() { return this.url; }
  const fileAttachments = new Map([
    ["data.json", {url: new URL("../data.json", import.meta.url), mimeType: "application/json", toString}]
  ]);
  main.builtin("FileAttachment", runtime.fileAttachments(name => fileAttachments.get(name)));
  main.variable(observer()).define(["md"], _1);
  main.variable(observer("data")).define("data", ["FileAttachment"], _data);
  main.variable(observer("yCounts")).define("yCounts", _yCounts);
  main.variable(observer("constellations")).define("constellations", ["data"], _constellations);
  main.variable(observer("cons")).define("cons", _cons);
  main.variable(observer()).define(["yCounts","constellations","cons","data"], _6);
  main.variable(observer("viewof plot2")).define("viewof plot2", ["Inputs"], _plot2);
  main.variable(observer("plot2")).define("plot2", ["Generators", "viewof plot2"], (G, _) => G.input(_));
  main.variable(observer()).define(["md"], _8);
  main.variable(observer()).define(["Plot","plot2","yCounts"], _9);
  main.variable(observer()).define(["md"], _10);
  main.variable(observer()).define(["Plot","plot2","cons","data"], _11);
  return main;
}
