<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Professional Edition 2013 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:altova="http://www.altova.com" xmlns:altovaext="http://www.altova.com/xslt-extensions" xmlns:clitype="clitype" xmlns:common="http://egov.bg/RegiX/MZH" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:iso4217="http://www.xbrl.org/2003/iso4217" xmlns:ix="http://www.xbrl.org/2008/inlineXBRL" xmlns:java="java" xmlns:link="http://www.xbrl.org/2003/linkbase" xmlns:n1="http://egov.bg/RegiX/MZH/FarmerSearchResponse" xmlns:sps="http://www.altova.com/StyleVision/user-xpath-functions" xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" exclude-result-prefixes="altova altovaext clitype common fn iso4217 ix java link n1 sps xbrldi xbrli xlink xs xsi">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:variable name="altova:nPxPerIn" select="96"/>
	<xsl:decimal-format name="format1" grouping-separator=" " decimal-separator=","/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
				<meta name="generator" content="Altova StyleVision Professional Edition 2013 sp1 (http://www.altova.com)"/>
				<meta http-equiv="X-UA-Compatible" content="IE=9"/>
				<xsl:comment>[if IE]&gt;&lt;STYLE type=&quot;text/css&quot;&gt;.altova-rotate-left-textbox{filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3)} .altova-rotate-right-textbox{filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1)} &lt;/STYLE&gt;&lt;![endif]</xsl:comment>
				<xsl:comment>[if !IE]&gt;&lt;!</xsl:comment>
				<style type="text/css">.altova-rotate-left-textbox{-webkit-transform: rotate(-90deg) translate(-100%, 0%); -webkit-transform-origin: 0% 0%;-moz-transform: rotate(-90deg) translate(-100%, 0%); -moz-transform-origin: 0% 0%;-ms-transform: rotate(-90deg) translate(-100%, 0%); -ms-transform-origin: 0% 0%;}.altova-rotate-right-textbox{-webkit-transform: rotate(90deg) translate(0%, -100%); -webkit-transform-origin: 0% 0%;-moz-transform: rotate(90deg) translate(0%, -100%); -moz-transform-origin: 0% 0%;-ms-transform: rotate(90deg) translate(0%, -100%); -ms-transform-origin: 0% 0%;}</style>
				<xsl:comment>&lt;![endif]</xsl:comment>
				<style type="text/css">@page { margin-left:0.60in; margin-right:0.60in; margin-top:0.79in; margin-bottom:0.79in } @media print { br.altova-page-break { page-break-before: always; } }</style>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:Farmer">
						<h3 style="text-align:center; ">
							<span>
								<xsl:text>Справка за земеделски производител</xsl:text>
							</span>
						</h3>
						<p>
							<xsl:for-each select="n1:AdministrativeData">
								<h4>
									<span>
										<xsl:text>Административни данни за регистрирания земеделски производител</xsl:text>
									</span>
								</h4>
								<ul>
									<xsl:for-each select="common:Entity">
										<xsl:for-each select="common:CompanyName">
											<li>
												<span>
													<xsl:text>Наименование:</xsl:text>
												</span>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</xsl:for-each>
								</ul>
								<xsl:if test="string-length(common:Person/common:Name)&gt;0 or string-length(common:Person/common:Surname)&gt;0 or string-length(common:Person/common:Family)&gt;0">
									<ul>
										<xsl:for-each select="common:Person">
											<li>
												<span>
													<xsl:text>Имена: </xsl:text>
												</span>
												<xsl:for-each select="common:Name">
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="common:Surname">
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="common:Family">
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</li>
										</xsl:for-each>
									</ul>
								</xsl:if>
								<ul>
									<xsl:for-each select="common:ActiveRegistration">
										<xsl:for-each select="common:RegistrationDate">
											<li>
												<span>
													<xsl:text>Дата на регистрация: </xsl:text>
												</span>
												<span>
													<xsl:variable name="altova:seqContentStrings_0">
														<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
														<xsl:text>.</xsl:text>
														<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
														<xsl:text>.</xsl:text>
														<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
													</xsl:variable>
													<xsl:variable name="altova:sContent_0" select="string($altova:seqContentStrings_0)"/>
													<xsl:value-of select="$altova:sContent_0"/>
												</span>
											</li>
										</xsl:for-each>
									</xsl:for-each>
								</ul>
								<ul>
									<xsl:for-each select="common:CancelledRegistration">
										<xsl:for-each select="common:CancelledDate">
											<li>
												<span>
													<xsl:text>Дата на отписване: </xsl:text>
												</span>
												<span>
													<xsl:variable name="altova:seqContentStrings_1">
														<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
														<xsl:text>.</xsl:text>
														<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
														<xsl:text>.</xsl:text>
														<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
													</xsl:variable>
													<xsl:variable name="altova:sContent_1" select="string($altova:seqContentStrings_1)"/>
													<xsl:value-of select="$altova:sContent_1"/>
												</span>
											</li>
										</xsl:for-each>
									</xsl:for-each>
								</ul>
							</xsl:for-each>
						</p>
						<p>
							<xsl:for-each select="n1:Lands">
								<h4>
									<span>
										<xsl:text>Данни за използвани земеделски земи</xsl:text>
									</span>
								</h4>
								<table style="border-collapse:collapse; " border="1">
									<xsl:variable name="altova:CurrContextGrid_2" select="."/>
									<thead>
										<tr>
											<th>
												<span>
													<xsl:text>ЕКАТТЕ на землище</xsl:text>
												</span>
											</th>
											<th>
												<span>
													<xsl:text>Обработвана земя общо</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="common:Land">
											<tr>
												<td>
													<xsl:for-each select="common:EKKATE">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="common:Infield">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:for-each>
						</p>
						<xsl:for-each select="n1:Crops">
							<p>
								<xsl:if test="count(common:Crop)">
									<h4>
										<span>
											<xsl:text>Данни за отглеждани култури</xsl:text>
										</span>
									</h4>
									<table style="border-collapse:collapse; " border="1">
										<xsl:variable name="altova:CurrContextGrid_3" select="."/>
										<thead>
											<tr>
												<th>
													<p>
														<span>
															<xsl:text>ЕКАТТЕ на землище</xsl:text>
														</span>
													</p>
												</th>
												<th>
													<p>
														<span>
															<xsl:text>Код на културата</xsl:text>
														</span>
													</p>
												</th>
												<th>
													<p>
														<span>
															<xsl:text>Вид на културата</xsl:text>
														</span>
													</p>
												</th>
												<th>
													<p>
														<span>
															<xsl:text>Засети площи (за текуща стопанска година)</xsl:text>
														</span>
													</p>
												</th>
												<th>
													<p>
														<span>
															<xsl:text>Намерения за засети площи (за следваща стопанска година)</xsl:text>
														</span>
													</p>
												</th>
											</tr>
										</thead>
										<tbody>
											<xsl:for-each select="common:Crop">
												<tr>
													<td>
														<xsl:for-each select="common:EKKATE">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:CropCode">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:CropName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:SownArea">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:IntendedSownAreaNextYear">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
											</xsl:for-each>
										</tbody>
									</table>
								</xsl:if>
							</p>
						</xsl:for-each>
						<xsl:for-each select="n1:Animals">
							<xsl:if test="count(common:Animal)&gt;0">
								<p>
									<h4>
										<span>
											<xsl:text>Данни за отглеждани животни</xsl:text>
										</span>
										<br/>
									</h4>
									<table style="border-collapse:collapse; " border="1">
										<xsl:variable name="altova:CurrContextGrid_4" select="."/>
										<thead>
											<tr>
												<th>
													<span>
														<xsl:text>ЕКАТТЕ на землище</xsl:text>
													</span>
												</th>
												<th>
													<span>
														<xsl:text>Код на категория животни</xsl:text>
													</span>
												</th>
												<th>
													<span>
														<xsl:text>Вид и категория животни</xsl:text>
													</span>
												</th>
												<th>
													<span>
														<xsl:text>Брой животни</xsl:text>
													</span>
												</th>
											</tr>
										</thead>
										<tbody>
											<xsl:for-each select="common:Animal">
												<tr>
													<td>
														<xsl:for-each select="common:EKKATE">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:AnimalCode">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:AnimalName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="common:Units">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
											</xsl:for-each>
										</tbody>
									</table>
								</p>
							</xsl:if>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
