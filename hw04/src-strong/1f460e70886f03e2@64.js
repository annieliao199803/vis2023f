function _1(md){return(
md`# HW04 strong baseline`
)}

function _artist(FileAttachment){return(
FileAttachment("artist.csv").csv()
)}

function _innerCircleQuestion(artist){return(
Object.keys(artist[0])[2]
)}

function _outerCircleQuestion(artist){return(
Object.keys(artist[0])[17]
)}

function _data(artist,innerCircleQuestion,outerCircleQuestion)
{
  // 提取內外圈問題的答案
  var innerCircleAnswer = artist.map(row => row[innerCircleQuestion]);
  var outerCircleAnswer = artist.map(row => row[outerCircleQuestion]);

  // 將內外圈答案結合，形成新的答案陣列
  var combinedAnswers = innerCircleAnswer.map((innerAns, index) => [innerAns, outerCircleAnswer[index]]);

  // 重新格式化答案，將其轉換為符合特定模式的陣列
  var reformattedAnswers = combinedAnswers.map(item => {
    const [innerAns, outerAns] = item;
    const splitOuterAns = outerAns.split(';').map(value => value.trim());
    return splitOuterAns.map(outerValue => [innerAns, outerValue]);
  }).reduce((acc, curr) => acc.concat(curr), []);

  // 計算每個重新格式化答案的出現次數
  var answerCounts = {};
  reformattedAnswers.forEach(reformattedAns => {
    const key = reformattedAns.join('-');
    answerCounts[key] = (answerCounts[key] || 0) + 1;
  });

  // 轉換為CSV格式的數據
  var csvData = Object.entries(answerCounts).map(([answer, count]) => {
    const [innerQuestion, outerQuestion] = answer.split('-');
    return [innerQuestion, outerQuestion, String(count)];
  });

  // 建立包含層次結構的數據
  return csvData;
}


function _chart(d3,data)
{
  // Specify the chart’s dimensions.
  const width = 928;
  const height = width;
  const marginTop = 30;
  const marginRight = -1;
  const marginBottom = -1;
  const marginLeft = 1;

  // Create the color scale.
  // 假設csvData的結構是 [內圈問題, 外圈問題, 次數]
  // 需要據此調整顏色比例尺的domain
  const color = d3.scaleOrdinal(d3.schemeCategory10).domain(data.map(d => d[1]));

  // Compute the layout.
  // 調整treemap以適應csvData的結構
  const treemap = data => d3.treemap()
      .round(true)
      .tile(d3.treemapSliceDice)
      .size([
        width - marginLeft - marginRight, 
        height - marginTop - marginBottom
      ])
    (d3.hierarchy(d3.group(data, d => d[0], d => d[1])).sum(d => +d[2]))
    .each(d => {
      d.x0 += marginLeft;
      d.x1 += marginLeft;
      d.y0 += marginTop;
      d.y1 += marginTop;
    });
  const root = treemap(data);

  // Create the SVG container.
  const svg = d3.create("svg")
      .attr("viewBox", [0, 0, width, height])
      .attr("width", width)
      .attr("height", height)
      .attr("style", "max-width: 100%; height: auto; font: 10px sans-serif;");


  // Position the nodes.
  const node = svg.selectAll("g")
    .data(root.descendants())
    .join("g")
      .attr("transform", d => `translate(${d.x0},${d.y0})`);

  const format = d => d.toLocaleString();

  // Draw column labels.
  const column = node.filter(d => d.depth === 1);

  
  
  column.append("text")
      .attr("x", 3)
      .attr("y", "-1.7em")
      .style("font-weight", "bold")
      .text(d => d.data[0]);

  column.append("text")
      .attr("x", 3)
      .attr("y", "-0.5em")
      .attr("fill-opacity", 0.7)
      .text(d => format(d.value));

  column.append("line")
      .attr("x1", -0.5)
      .attr("x2", -0.5)
      .attr("y1", -30)
      .attr("y2", d => d.y1 - d.y0)
      .attr("stroke", "#000")

  // Draw leaves.
  const cell = node.filter(d => d.depth === 2);

  cell.append("rect")
      .attr("fill", d => color(d.data[0]))
      .attr("fill-opacity", (d, i) => d.value / d.parent.value)
      .attr("width", d => d.x1 - d.x0 - 1)
      .attr("height", d => d.y1 - d.y0 - 1)
      .on("mouseover", function(event, d) {
      // 鼠标悬停时的行为，例如改变矩形的样式
      d3.select(this).style("stroke", "black").style("stroke-width", 2);
          })
      .on("mouseout", function(d) {
        // 鼠标离开时恢复矩形的原始样式
        d3.select(this).style("stroke", null).style("stroke-width", null);
      });

  cell.append("text")
      .attr("x", 3)
      .attr("y", "1.1em")
      .text(d => {
            if(d.data[0] === "不清楚，需要更多資訊。") {
              return "不清楚";
            }
            return d.data[0];
          });
      // .text(d => d.data[0]);

  cell.append("text")
      .attr("x", 3)
      .attr("y", "2.3em")
      .attr("fill-opacity", 0.7)
      .text(d => format(d.value));


  return svg.node();
}


function _7(htl){return(
htl.html`<h2>結論</h2>
<h3>從上圖中，我們可以看出：
  <ul>
    <li>在北部工作的人占此問卷的多數</li>
    <li>北部中部及南部的工作者，大部分認為以數位形式舉辦藝文展覽可以降低碳排放</li>
    <li>國外的工作者樣本數太少，沒有參考價值</li>
  </ul>
</h3>`
)}

export default function define(runtime, observer) {
  const main = runtime.module();
  function toString() { return this.url; }
  const fileAttachments = new Map([
    ["artist.csv", {url: new URL("./artist.csv", import.meta.url), mimeType: "text/csv", toString}]
  ]);
  main.builtin("FileAttachment", runtime.fileAttachments(name => fileAttachments.get(name)));
  main.variable(observer()).define(["md"], _1);
  main.variable(observer("artist")).define("artist", ["FileAttachment"], _artist);
  main.variable(observer("innerCircleQuestion")).define("innerCircleQuestion", ["artist"], _innerCircleQuestion);
  main.variable(observer("outerCircleQuestion")).define("outerCircleQuestion", ["artist"], _outerCircleQuestion);
  main.variable(observer("data")).define("data", ["artist","innerCircleQuestion","outerCircleQuestion"], _data);
  main.variable(observer("chart")).define("chart", ["d3","data"], _chart);
  main.variable(observer()).define(["htl"], _7);
  return main;
}
