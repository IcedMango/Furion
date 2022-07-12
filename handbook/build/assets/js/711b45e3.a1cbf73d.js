"use strict";(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[984],{7870:function(e,r,n){n.r(r),n.d(r,{assets:function(){return d},contentTitle:function(){return s},default:function(){return m},frontMatter:function(){return i},metadata:function(){return l},toc:function(){return u}});var t=n(3117),a=n(102),p=(n(7294),n(3905)),o=["components"],i={id:"dapper",title:"10.2. Dapper \u96c6\u6210",sidebar_label:"10.2. Dapper \u96c6\u6210"},s=void 0,l={unversionedId:"dapper",id:"dapper",title:"10.2. Dapper \u96c6\u6210",description:"\u5728 Furion \u5305\u4e2d\u9ed8\u8ba4\u96c6\u6210\u4e86 EFCore\uff0c\u5982\u679c\u4e0d\u4f7f\u7528 EFCore\uff0c\u53ef\u5b89\u88c5\u7eaf\u51c0\u7248 Furion.Pure \u4ee3\u66ff Furion\u3002",source:"@site/docs/dapper.mdx",sourceDirName:".",slug:"/dapper",permalink:"/furion/docs/dapper",draft:!1,editUrl:"https://gitee.com/dotnetchina/Furion/tree/net6/handbook/docs/dapper.mdx",tags:[],version:"current",lastUpdatedBy:"MonkSoul",lastUpdatedAt:1654567463,formattedLastUpdatedAt:"Jun 7, 2022",frontMatter:{id:"dapper",title:"10.2. Dapper \u96c6\u6210",sidebar_label:"10.2. Dapper \u96c6\u6210"},sidebar:"docs",previous:{title:"10.1. SqlSugar \u96c6\u6210",permalink:"/furion/docs/sqlsugar"},next:{title:"10.3. MongoDB \u64cd\u4f5c",permalink:"/furion/docs/mongodb"}},d={},u=[{value:"10.2.1 \u5173\u4e8e Dapper",id:"1021-\u5173\u4e8e-dapper",level:2},{value:"10.2.2 \u5982\u4f55\u96c6\u6210",id:"1022-\u5982\u4f55\u96c6\u6210",level:2},{value:"10.2.2.1 \u6ce8\u518c <code>Dapper</code> \u670d\u52a1",id:"10221-\u6ce8\u518c-dapper-\u670d\u52a1",level:3},{value:"10.2.2.2 \u5b89\u88c5\u5bf9\u5e94\u7684\u6570\u636e\u5e93\u63d0\u4f9b\u5668",id:"10222-\u5b89\u88c5\u5bf9\u5e94\u7684\u6570\u636e\u5e93\u63d0\u4f9b\u5668",level:3},{value:"10.2.3 \u57fa\u672c\u4f7f\u7528",id:"1023-\u57fa\u672c\u4f7f\u7528",level:2},{value:"10.2.3.1 <code>sql</code> \u64cd\u4f5c",id:"10231-sql-\u64cd\u4f5c",level:3},{value:"10.2.3.2 <code>&lt;TEntity&gt;</code> \u64cd\u4f5c",id:"10232-tentity-\u64cd\u4f5c",level:3},{value:"10.2.4 \u9ad8\u7ea7\u4f7f\u7528",id:"1024-\u9ad8\u7ea7\u4f7f\u7528",level:2},{value:"10.2.4.1 \u67e5\u8be2\u4e00\u5bf9\u4e00",id:"10241-\u67e5\u8be2\u4e00\u5bf9\u4e00",level:3},{value:"10.2.4.2 \u67e5\u8be2\u591a\u4e2a\u7ed3\u679c",id:"10242-\u67e5\u8be2\u591a\u4e2a\u7ed3\u679c",level:3},{value:"10.2.4.3 \u66f4\u591a\u64cd\u4f5c",id:"10243-\u66f4\u591a\u64cd\u4f5c",level:3},{value:"10.2.5 \u53cd\u9988\u4e0e\u5efa\u8bae",id:"1025-\u53cd\u9988\u4e0e\u5efa\u8bae",level:2}],c={toc:u};function m(e){var r=e.components,n=(0,a.Z)(e,o);return(0,p.kt)("wrapper",(0,t.Z)({},c,n,{components:r,mdxType:"MDXLayout"}),(0,p.kt)("admonition",{title:"\u6e29\u99a8\u63d0\u9192",type:"warning"},(0,p.kt)("p",{parentName:"admonition"},"\u5728 ",(0,p.kt)("inlineCode",{parentName:"p"},"Furion")," \u5305\u4e2d\u9ed8\u8ba4\u96c6\u6210\u4e86 ",(0,p.kt)("inlineCode",{parentName:"p"},"EFCore"),"\uff0c",(0,p.kt)("strong",{parentName:"p"},"\u5982\u679c\u4e0d\u4f7f\u7528 ",(0,p.kt)("inlineCode",{parentName:"strong"},"EFCore"),"\uff0c\u53ef\u5b89\u88c5\u7eaf\u51c0\u7248 ",(0,p.kt)("inlineCode",{parentName:"strong"},"Furion.Pure")," \u4ee3\u66ff ",(0,p.kt)("inlineCode",{parentName:"strong"},"Furion")),"\u3002")),(0,p.kt)("h2",{id:"1021-\u5173\u4e8e-dapper"},"10.2.1 \u5173\u4e8e Dapper"),(0,p.kt)("p",null,(0,p.kt)("inlineCode",{parentName:"p"},"Dapper")," \u662f .NET/C# \u5e73\u53f0\u975e\u5e38\u4f18\u79c0\u7684 ",(0,p.kt)("inlineCode",{parentName:"p"},"\u5fae\u578b ORM")," \u6846\u67b6\uff0c\u4e3b\u8981\u662f\u4e3a ",(0,p.kt)("inlineCode",{parentName:"p"},"ADO.NET")," \u64cd\u4f5c\u5bf9\u8c61\u63d0\u4f9b\u62d3\u5c55\u80fd\u529b\uff0c\u63a8\u5d07\u539f\u751f ",(0,p.kt)("inlineCode",{parentName:"p"},"sql")," \u64cd\u4f5c\u6cd5\u3002"),(0,p.kt)("p",null,(0,p.kt)("inlineCode",{parentName:"p"},"Dapper")," \u5b98\u65b9\u4ed3\u5e93\u5730\u5740\uff1a",(0,p.kt)("a",{parentName:"p",href:"https://github.com/StackExchange/Dapper"},"https://github.com/StackExchange/Dapper")),(0,p.kt)("h2",{id:"1022-\u5982\u4f55\u96c6\u6210"},"10.2.2 \u5982\u4f55\u96c6\u6210"),(0,p.kt)("p",null,"\u5728 ",(0,p.kt)("inlineCode",{parentName:"p"},"Furion")," \u6846\u67b6\u4e2d\uff0c\u5df2\u7ecf\u63a8\u51fa ",(0,p.kt)("inlineCode",{parentName:"p"},"Dapper")," \u62d3\u5c55\u5305 ",(0,p.kt)("a",{parentName:"p",href:"https://www.nuget.org/packages/Furion.Extras.DatabaseAccessor.Dapper"},"Furion.Extras.DatabaseAccessor.Dapper"),"\u3002"),(0,p.kt)("h3",{id:"10221-\u6ce8\u518c-dapper-\u670d\u52a1"},"10.2.2.1 \u6ce8\u518c ",(0,p.kt)("inlineCode",{parentName:"h3"},"Dapper")," \u670d\u52a1"),(0,p.kt)("p",null,"\u4f7f\u7528\u975e\u5e38\u7b80\u5355\uff0c\u53ea\u9700\u8981\u5728 ",(0,p.kt)("inlineCode",{parentName:"p"},"Startup.cs")," \u4e2d\u6dfb\u52a0 ",(0,p.kt)("inlineCode",{parentName:"p"},"services.AddDapper(connStr, SqlProvider)")," \u5373\u53ef\u3002\u5982\uff1a"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'services.AddDapper("Data Source=./Furion.db", SqlProvider.Sqlite);\n\n// \u66f4\u591a\u914d\u7f6e\uff0c\u4ec5 v3.4.3+ \u7248\u672c\u6709\u6548\nservers.AddDapper("Data Source=./Furion.db", SqlProvider.Sqlite, () => {\n  DefaultTypeMap.MatchNamesWithUnderscores = true;\n})\n')),(0,p.kt)("h3",{id:"10222-\u5b89\u88c5\u5bf9\u5e94\u7684\u6570\u636e\u5e93\u63d0\u4f9b\u5668"},"10.2.2.2 \u5b89\u88c5\u5bf9\u5e94\u7684\u6570\u636e\u5e93\u63d0\u4f9b\u5668"),(0,p.kt)("ul",null,(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"SqlServer"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"Microsoft.Data.SqlClient")),(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"Sqlite"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"Microsoft.Data.Sqlite")),(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"MySql"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"MySql.Data")),(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"Npgsql"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"Npgsql")),(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"Oracle"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"Oracle.ManagedDataAccess.Core")),(0,p.kt)("li",{parentName:"ul"},(0,p.kt)("inlineCode",{parentName:"li"},"Firebird"),"\uff1a",(0,p.kt)("inlineCode",{parentName:"li"},"FirebirdSql.Data.FirebirdClient"))),(0,p.kt)("admonition",{title:"\u5b89\u88c5\u62d3\u5c55\u5305\u4f4d\u7f6e",type:"important"},(0,p.kt)("p",{parentName:"admonition"},"\u5728 ",(0,p.kt)("inlineCode",{parentName:"p"},"Furion")," \u6846\u67b6\u4e2d\uff0c\u63a8\u8350\u5c06\u62d3\u5c55\u5305 ",(0,p.kt)("inlineCode",{parentName:"p"},"Furion.Extras.DatabaseAccessor.Dapper")," \u5b89\u88c5\u5230 ",(0,p.kt)("inlineCode",{parentName:"p"},"Furion.Core")," \u5c42\u4e2d\u3002")),(0,p.kt)("h2",{id:"1023-\u57fa\u672c\u4f7f\u7528"},"10.2.3 \u57fa\u672c\u4f7f\u7528"),(0,p.kt)("p",null,"\u5728\u4f7f\u7528\u4e4b\u524d\uff0c\u6211\u4eec\u53ef\u4ee5\u901a\u8fc7\u6784\u9020\u51fd\u6570\u6ce8\u5165 ",(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository")," \u6216 ",(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository<TEntity>")," \u63a5\u53e3\uff0c\u5982\uff1a"),(0,p.kt)("ul",null,(0,p.kt)("li",{parentName:"ul"},"\u975e\u6cdb\u578b\u7248\u672c")),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},"private readonly IDapperRepository _dapperRepository;\npublic PersonService(IDapperRepository dapperRepository)\n{\n    _dapperRepository = dapperRepository;\n}\n")),(0,p.kt)("ul",null,(0,p.kt)("li",{parentName:"ul"},"\u6cdb\u578b\u7248\u672c")),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},"private readonly IDapperRepository<Person> _personRepository;\npublic PersonService(IDapperRepository<Person> personRepository)\n{\n    _personRepository = personRepository;\n}\n")),(0,p.kt)("h3",{id:"10231-sql-\u64cd\u4f5c"},"10.2.3.1 ",(0,p.kt)("inlineCode",{parentName:"h3"},"sql")," \u64cd\u4f5c"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'var data = _dapperRepository.Query("select * from person");\nvar data = await _dapperRepository.QueryAsync("select * from person");\n\nvar data = _dapperRepository.Query<Person>("select * from person");\n\nvar guid = Guid.NewGuid();\nvar dog = _dapperRepository.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });\n')),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'var count = _dapperRepository.Execute(@"insert MyTable(colA, colB) values (@a, @b)",\n    new[] { new { a=1, b=1 }, new { a=2, b=2 }, new { a=3, b=3 } }\n  );\n\nvar user = _dapperRepository.Query<User>("spGetUser", new {Id = 1},\n        commandType: CommandType.StoredProcedure).SingleOrDefault();\n')),(0,p.kt)("p",null,"\u7528\u6cd5\u548c\u5b98\u65b9\u4e00\u81f4\uff0c\u6b64\u5904\u4e0d\u518d\u4e3e\u66f4\u591a\u4f8b\u5b50\u3002"),(0,p.kt)("h3",{id:"10232-tentity-\u64cd\u4f5c"},"10.2.3.2 ",(0,p.kt)("inlineCode",{parentName:"h3"},"<TEntity>")," \u64cd\u4f5c"),(0,p.kt)("p",null,(0,p.kt)("inlineCode",{parentName:"p"},"Furion")," \u6846\u67b6\u63d0\u4f9b\u4e86 ",(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository")," \u548c ",(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository<TEntity>")," \u4e24\u4e2a\u64cd\u4f5c\u4ed3\u50a8\uff0c\u540e\u8005\u7ee7\u627f\u524d\u8005\u3002\u4f7f\u7528\u5982\u4e0b\uff1a"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},"var person = personRepository.Get(1);\nvar persons = personRepository.GetAll();\n\nvar effects = personRepository.Insert(person);\nvar effects = personRepository.Update(person);\nvar effects = personRepository.Delete(person);\n\nvar effects = personRepository.Insert(persons); // \u63d2\u5165\u591a\u4e2a\nvar effects = personRepository.Update(persons); // \u66f4\u65b0\u591a\u4e2a\nvar effects = personRepository.Delete(persons); // \u5220\u9664\u591a\u4e2a\n\nvar effects = await personRepository.InsertAsync(person);\n")),(0,p.kt)("h2",{id:"1024-\u9ad8\u7ea7\u4f7f\u7528"},"10.2.4 \u9ad8\u7ea7\u4f7f\u7528"),(0,p.kt)("p",null,(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository")," \u548c ",(0,p.kt)("inlineCode",{parentName:"p"},"IDapperRepository<TEntity>")," \u4ed3\u50a8\u63d0\u4f9b\u4e86 ",(0,p.kt)("inlineCode",{parentName:"p"},"Context")," \u548c ",(0,p.kt)("inlineCode",{parentName:"p"},"DynamicContext")," \u5c5e\u6027\uff0c\u8be5\u5c5e\u6027\u8fd4\u56de ",(0,p.kt)("inlineCode",{parentName:"p"},"IDbConnection")," \u5bf9\u8c61\u3002"),(0,p.kt)("p",null,"\u62ff\u5230\u8be5\u5bf9\u8c61\u540e\uff0c\u6211\u4eec\u5c31\u53ef\u4ee5\u64cd\u4f5c ",(0,p.kt)("inlineCode",{parentName:"p"},"Dapper")," \u63d0\u4f9b\u7684\u6240\u6709\u64cd\u4f5c\u4e86\uff0c\u5982\uff1a"),(0,p.kt)("h3",{id:"10241-\u67e5\u8be2\u4e00\u5bf9\u4e00"},"10.2.4.1 \u67e5\u8be2\u4e00\u5bf9\u4e00"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'var sql =\n@"select * from #Posts p\nleft join #Users u on u.Id = p.OwnerId\nOrder by p.Id";\n\nvar data = dapperRepository.Context.Query<Post, User, Post>(sql, (post, user) => { post.Owner = user; return post;});\nvar post = data.First();\n')),(0,p.kt)("h3",{id:"10242-\u67e5\u8be2\u591a\u4e2a\u7ed3\u679c"},"10.2.4.2 \u67e5\u8be2\u591a\u4e2a\u7ed3\u679c"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'var sql =\n@"\nselect * from Customers where CustomerId = @id\nselect * from Orders where CustomerId = @id\nselect * from Returns where CustomerId = @id";\n\nusing (var multi = dapperRepository.Context.QueryMultiple(sql, new {id=selectedId}))\n{\n  var customer = multi.Read<Customer>().Single();\n  var orders = multi.Read<Order>().ToList();\n  var returns = multi.Read<Return>().ToList();\n  // ...\n}\n')),(0,p.kt)("h3",{id:"10243-\u66f4\u591a\u64cd\u4f5c"},"10.2.4.3 \u66f4\u591a\u64cd\u4f5c"),(0,p.kt)("pre",null,(0,p.kt)("code",{parentName:"pre",className:"language-cs",metastring:"showLineNumbers",showLineNumbers:!0},'var shapes = new List<IShape>();\nusing (var reader = dapperRepository.Context.ExecuteReader("select * from Shapes"))\n{\n   var circleParser = reader.GetRowParser<IShape>(typeof(Circle));\n   var squareParser = reader.GetRowParser<IShape>(typeof(Square));\n   var triangleParser = reader.GetRowParser<IShape>(typeof(Triangle));\n\n   var typeColumnIndex = reader.GetOrdinal("Type");\n\n   while (reader.Read())\n   {\n       IShape shape;\n       var type = (ShapeType)reader.GetInt32(typeColumnIndex);\n       switch (type)\n       {\n           case ShapeType.Circle:\n            shape = circleParser(reader);\n            break;\n           case ShapeType.Square:\n            shape = squareParser(reader);\n            break;\n           case ShapeType.Triangle:\n            shape = triangleParser(reader);\n            break;\n           default:\n            throw new NotImplementedException();\n       }\n\n        shapes.Add(shape);\n   }\n}\n')),(0,p.kt)("h2",{id:"1025-\u53cd\u9988\u4e0e\u5efa\u8bae"},"10.2.5 \u53cd\u9988\u4e0e\u5efa\u8bae"),(0,p.kt)("admonition",{title:"\u4e0e\u6211\u4eec\u4ea4\u6d41",type:"note"},(0,p.kt)("p",{parentName:"admonition"},"\u7ed9 Furion \u63d0 ",(0,p.kt)("a",{parentName:"p",href:"https://gitee.com/dotnetchina/Furion/issues/new?issue"},"Issue"),"\u3002")),(0,p.kt)("hr",null),(0,p.kt)("admonition",{title:"\u4e86\u89e3\u66f4\u591a",type:"note"},(0,p.kt)("p",{parentName:"admonition"},"\u60f3\u4e86\u89e3\u66f4\u591a ",(0,p.kt)("inlineCode",{parentName:"p"},"Dapper")," \u77e5\u8bc6\u53ef\u67e5\u9605 ",(0,p.kt)("a",{parentName:"p",href:"https://github.com/StackExchange/Dapper"},"Dapper \u5b98\u7f51"),"\u3002")))}m.isMDXComponent=!0},3905:function(e,r,n){n.d(r,{Zo:function(){return d},kt:function(){return m}});var t=n(7294);function a(e,r,n){return r in e?Object.defineProperty(e,r,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[r]=n,e}function p(e,r){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var t=Object.getOwnPropertySymbols(e);r&&(t=t.filter((function(r){return Object.getOwnPropertyDescriptor(e,r).enumerable}))),n.push.apply(n,t)}return n}function o(e){for(var r=1;r<arguments.length;r++){var n=null!=arguments[r]?arguments[r]:{};r%2?p(Object(n),!0).forEach((function(r){a(e,r,n[r])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):p(Object(n)).forEach((function(r){Object.defineProperty(e,r,Object.getOwnPropertyDescriptor(n,r))}))}return e}function i(e,r){if(null==e)return{};var n,t,a=function(e,r){if(null==e)return{};var n,t,a={},p=Object.keys(e);for(t=0;t<p.length;t++)n=p[t],r.indexOf(n)>=0||(a[n]=e[n]);return a}(e,r);if(Object.getOwnPropertySymbols){var p=Object.getOwnPropertySymbols(e);for(t=0;t<p.length;t++)n=p[t],r.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var s=t.createContext({}),l=function(e){var r=t.useContext(s),n=r;return e&&(n="function"==typeof e?e(r):o(o({},r),e)),n},d=function(e){var r=l(e.components);return t.createElement(s.Provider,{value:r},e.children)},u={inlineCode:"code",wrapper:function(e){var r=e.children;return t.createElement(t.Fragment,{},r)}},c=t.forwardRef((function(e,r){var n=e.components,a=e.mdxType,p=e.originalType,s=e.parentName,d=i(e,["components","mdxType","originalType","parentName"]),c=l(n),m=a,k=c["".concat(s,".").concat(m)]||c[m]||u[m]||p;return n?t.createElement(k,o(o({ref:r},d),{},{components:n})):t.createElement(k,o({ref:r},d))}));function m(e,r){var n=arguments,a=r&&r.mdxType;if("string"==typeof e||a){var p=n.length,o=new Array(p);o[0]=c;var i={};for(var s in r)hasOwnProperty.call(r,s)&&(i[s]=r[s]);i.originalType=e,i.mdxType="string"==typeof e?e:a,o[1]=i;for(var l=2;l<p;l++)o[l]=n[l];return t.createElement.apply(null,o)}return t.createElement.apply(null,n)}c.displayName="MDXCreateElement"}}]);