<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Professional Edition 2013 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:altova="http://www.altova.com" xmlns:altovaext="http://www.altova.com/xslt-extensions" xmlns:clitype="clitype" xmlns:cr="http://egov.bg/RegiX/CROZ/CROZ" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:iso4217="http://www.xbrl.org/2003/iso4217" xmlns:ix="http://www.xbrl.org/2008/inlineXBRL" xmlns:java="java" xmlns:link="http://www.xbrl.org/2003/linkbase" xmlns:n1="http://egov.bg/RegiX/CROZ/CROZ/DealInfoResponse" xmlns:sps="http://www.altova.com/StyleVision/user-xpath-functions" xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" exclude-result-prefixes="altova altovaext clitype cr fn iso4217 ix java link n1 sps xbrldi xbrli xlink xs xsi">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:param name="documentId"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:variable name="altova:nPxPerIn" select="96"/>
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
					<xsl:for-each select="n1:DealInfoResponse">
						<h3 style="font-size:20px; text-align:center; ">
							<span style="font-size:20px; ">
								<xsl:text>Справка за вписвания във връзка с определена сделка в Централния регистър на особените залози</xsl:text>
							</span>
						</h3>
						<xsl:if test="string-length(n1:deal) &gt; 0">
							<div style="color:black; font-size:16px; text-align:center; ">
								<xsl:choose>
									<xsl:when test="n1:archiveLikeFilter = &quot;ALL&quot;">
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>(с включени архивирани вписвания)</xsl:text>
										</span>
									</xsl:when>
									<xsl:otherwise>
										<span>
											<xsl:text>(</xsl:text>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>само действащи вписвания)</xsl:text>
										</span>
									</xsl:otherwise>
								</xsl:choose>
							</div>
						</xsl:if>
						<br/>
						<xsl:for-each select="n1:synchronizationDate">
							<span style="font-style:italic; ">
								<xsl:apply-templates/>
							</span>
							<br/>
							<br/>
						</xsl:for-each>
						<xsl:if test="string-length(n1:deal) = 0">
							<span>
								<xsl:text>Не са открити данни по посочените критерии за търсене.</xsl:text>
							</span>
						</xsl:if>
						<xsl:for-each select="n1:deal[string-length(.) &gt; 0]">
							<xsl:for-each select="cr:entry">
								<xsl:for-each select="cr:regId">
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:text>Сделка № </xsl:text>
									</span>
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:text>, </xsl:text>
									</span>
								</xsl:for-each>
								<xsl:for-each select="cr:description">
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
								</xsl:for-each>
								<br/>
								<br/>
								<span style="font-size:16px; font-weight:bold; text-decoration:underline; ">
									<xsl:text>1. Първоначално вписване</xsl:text>
								</span>
								<xsl:if test="cr:scanned = &quot;N&quot;">
									<br/>
									<span style="font-size:16px; ">
										<xsl:text>Въвеждането на информация по това вписване не е завършено!</xsl:text>
									</span>
								</xsl:if>
								<xsl:choose>
									<xsl:when test="cr:status = &quot;C&quot;">
										<br/>
										<span style="font-size:16px; margin-left:0.5cm; ">
											<xsl:text>Вписването </xsl:text>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>е</xsl:text>
										</span>
										<span style="font-size:16px; ">
											<xsl:text> условно</xsl:text>
										</span>
									</xsl:when>
									<xsl:otherwise>
										<br/>
										<span style="font-size:16px; margin-left:0.5cm; ">
											<xsl:text>Вписването </xsl:text>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>не е</xsl:text>
										</span>
										<span style="font-size:16px; ">
											<xsl:text> условно.</xsl:text>
										</span>
									</xsl:otherwise>
								</xsl:choose>
								<br/>
								<span style="font-size:16px; margin-left:0.5cm; ">
									<xsl:text>Дата и час на вписването: </xsl:text>
								</span>
								<xsl:for-each select="cr:reg_date">
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
								</xsl:for-each>
								<xsl:for-each select="cr:reg_time">
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:text>&#160;</xsl:text>
									</span>
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="cr:creditors">
									<span style="font-size:16px; margin-left:0.5cm; ">
										<xsl:text>Вписаните права са на:</xsl:text>
									</span>
									<br/>
									<xsl:for-each select="cr:participant">
										<span style="font-size:16px; font-weight:bold; margin-left:1cm; ">
											<xsl:value-of select="position()"/>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>.</xsl:text>
										</span>
										<span style="font-size:16px; ">
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:for-each select="cr:particip_id_code">
											<span style="font-size:16px; ">
												<xsl:text>Идентификационен код: </xsl:text>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<span style="font-size:16px; margin-left:1.5cm; ">
											<xsl:text>Име:&#160; </xsl:text>
										</span>
										<xsl:for-each select="cr:full_name">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<span style="font-size:16px; margin-left:1.5cm; ">
											<xsl:text>Адрес: </xsl:text>
										</span>
										<xsl:for-each select="cr:zip">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>&#160;</xsl:text>
											</span>
										</xsl:for-each>
										<xsl:if test="string-length( cr:zip )&gt;0">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>, </xsl:text>
											</span>
										</xsl:if>
										<xsl:for-each select="cr:city">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<xsl:if test="string-length( cr:zip )&gt;0 or string-length( cr:city )&gt;0">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>, </xsl:text>
											</span>
										</xsl:if>
										<xsl:for-each select="cr:address">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="cr:debtors">
									<span style="font-size:16px; margin-left:0.5cm; ">
										<xsl:text>Вписването е по партида на:</xsl:text>
									</span>
									<br/>
									<xsl:for-each select="cr:participant">
										<span style="font-size:16px; font-weight:bold; margin-left:1cm; ">
											<xsl:value-of select="position()"/>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:text>.</xsl:text>
										</span>
										<span style="font-size:16px; ">
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:for-each select="cr:particip_id_code">
											<span style="font-size:16px; ">
												<xsl:text>Идентификационен код: </xsl:text>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<span style="font-size:16px; margin-left:1.5cm; ">
											<xsl:text>Име: </xsl:text>
										</span>
										<xsl:for-each select="cr:full_name">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<span style="font-size:16px; margin-left:1.5cm; ">
											<xsl:text>Адрес: </xsl:text>
										</span>
										<xsl:for-each select="cr:zip">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>&#160;</xsl:text>
											</span>
										</xsl:for-each>
										<xsl:if test="string-length( cr:zip )&gt;0">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>, </xsl:text>
											</span>
										</xsl:if>
										<xsl:for-each select="cr:city">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<xsl:if test="string-length( cr:zip )&gt;0 or string-length( cr:city )&gt;0">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>, </xsl:text>
											</span>
										</xsl:if>
										<xsl:for-each select="cr:address">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
								<div style="margin-left:0.5cm; ">
									<xsl:for-each select="cr:page_numbers">
										<span style="font-size:16px; ">
											<xsl:text>Описание на имуществото и друга информация за вписването: Оптичен архив, състоящ се от </xsl:text>
										</span>
										<span style="font-size:16px; font-weight:bold; ">
											<xsl:apply-templates/>
										</span>
										<span style="font-size:16px; ">
											<xsl:text> страници;</xsl:text>
										</span>
									</xsl:for-each>
								</div>
								<div style="margin-left:0.5cm; ">
									<xsl:if test="cr:retId=&apos;01&apos;">
										<span style="font-size:16px; ">
											<xsl:text>Регистрационни номера на вписани запори върху обезпеченото вземане: </xsl:text>
										</span>
										<xsl:choose>
											<xsl:when test="count( cr:distrainSecuredClaims/cr:distrainSecuredClaim )=0">
												<span style="font-size:16px; font-weight:bold; margin-left:0.5cm; ">
													<xsl:text>НЕ</xsl:text>
												</span>
											</xsl:when>
											<xsl:otherwise>
												<xsl:for-each select="cr:distrainSecuredClaims">
													<xsl:for-each select="cr:distrainSecuredClaim">
														<br/>
														<span style="font-size:16px; font-weight:bold; margin-left:1cm; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:if>
								</div>
								<div style="margin-left:0.5cm; ">
									<xsl:if test="cr:retId=&apos;04&apos;">
										<span style="font-size:16px; ">
											<xsl:text>Регистрационен номер на залог върху вземане: </xsl:text>
										</span>
										<xsl:choose>
											<xsl:when test="string-length( cr:pledgeOnClaim )=0">
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:text>НЕ</xsl:text>
												</span>
											</xsl:when>
											<xsl:otherwise>
												<xsl:for-each select="cr:pledgeOnClaim">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:if>
								</div>
								<xsl:for-each select="cr:expire_date">
									<span style="font-size:16px; margin-left:0.5cm; ">
										<xsl:text>Дата на която се прекратява действието на вписването: </xsl:text>
									</span>
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:apply-templates/>
									</span>
								</xsl:for-each>
								<div style="font-size:16px; ">
									<xsl:for-each select="cr:oa_pole17">
										<xsl:for-each select="cr:oas">
											<br/>
											<xsl:for-each select="$XML">
												<xsl:for-each select="n1:DealInfoResponse">
													<xsl:for-each select="n1:deal">
														<xsl:for-each select="cr:entry">
															<xsl:for-each select="cr:opis_header">
																<span style="font-size:16px; font-weight:bold; margin-left:0.5cm; ">
																	<xsl:apply-templates/>
																</span>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
											<xsl:if test="string-length(../../cr:opis_header) &gt; 0">
												<xsl:for-each select="cr:regId">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>&#160;</xsl:text>
													</span>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
											</xsl:if>
											<xsl:for-each select="cr:imgFace">
												<br/>
												<img style="font-size:16px; ">
													<xsl:attribute name="src">
														<xsl:if test="substring(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), 2, 1) = ':'">
															<xsl:text>file:///</xsl:text>
														</xsl:if>
														<xsl:value-of select="translate(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), '&#x5c;', '/')"/>
													</xsl:attribute>
													<xsl:attribute name="alt"/>
												</img>
											</xsl:for-each>
											<xsl:for-each select="cr:imgBack">
												<br/>
												<img style="font-size:16px; ">
													<xsl:attribute name="src">
														<xsl:if test="substring(string(concat(&quot;data:&quot;, ../cr:imgBackType, &quot;;base64,&quot;, string(.))), 2, 1) = ':'">
															<xsl:text>file:///</xsl:text>
														</xsl:if>
														<xsl:value-of select="translate(string(concat(&quot;data:&quot;, ../cr:imgBackType, &quot;;base64,&quot;, string(.))), '&#x5c;', '/')"/>
													</xsl:attribute>
													<xsl:attribute name="alt"/>
												</img>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</div>
								<br/>
							</xsl:for-each>
							<xsl:for-each select="cr:amendments">
								<br/>
								<span style="font-size:16px; font-weight:bold; text-decoration:underline; ">
									<xsl:text>2. Допълнителни вписвания</xsl:text>
								</span>
								<xsl:if test="count( cr:amendments/cr:entry )=0">
									<br/>
									<br/>
									<span style="font-size:16px; font-weight:bold; margin-left:0.5cm; ">
										<xsl:text>НЯМА</xsl:text>
									</span>
								</xsl:if>
								<br/>
								<xsl:for-each select="cr:amendments">
									<span style="font-size:16px; font-weight:bold; margin-left:0.5cm; ">
										<xsl:value-of select="position()"/>
									</span>
									<span style="font-size:16px; font-weight:bold; ">
										<xsl:text>.</xsl:text>
									</span>
									<span style="font-size:16px; ">
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:for-each select="cr:entry">
										<xsl:if test="count(parent::cr:amendments/preceding-sibling::cr:amendments/cr:entry[cr:scanned=&apos;N&apos;])=0 and cr:scanned=&apos;N&apos; and ../../../cr:entry/cr:scanned=&apos;Y&apos;">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>Внимание! Информацията е актуална до момента преди:</xsl:text>
											</span>
											<br/>
										</xsl:if>
										<xsl:for-each select="cr:regId">
											<span style="font-size:16px; margin-left:0.5cm; ">
												<xsl:text>Номер на разпореждането за вписване: </xsl:text>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<xsl:if test="cr:scanned = &quot;N&quot;">
											<br/>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>Въвеждането на информация по това вписване не е завършено!</xsl:text>
											</span>
										</xsl:if>
										<xsl:choose>
											<xsl:when test="cr:status = &quot;C&quot;">
												<br/>
												<span style="font-size:16px; margin-left:1cm; ">
													<xsl:text>Вписването </xsl:text>
												</span>
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:text>е </xsl:text>
												</span>
												<span style="font-size:16px; ">
													<xsl:text>условно.</xsl:text>
												</span>
											</xsl:when>
											<xsl:otherwise>
												<br/>
												<span style="font-size:16px; margin-left:1cm; ">
													<xsl:text>Вписването </xsl:text>
												</span>
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:text>не е</xsl:text>
												</span>
												<span style="font-size:16px; ">
													<xsl:text> условно.</xsl:text>
												</span>
											</xsl:otherwise>
										</xsl:choose>
										<br/>
										<span style="font-size:16px; margin-left:1cm; ">
											<xsl:text>Дата и час на вписването: </xsl:text>
										</span>
										<xsl:for-each select="cr:reg_date">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>&#160;</xsl:text>
											</span>
										</xsl:for-each>
										<xsl:for-each select="cr:reg_time">
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<span style="font-size:16px; margin-left:1cm; ">
											<xsl:text>Предмет на вписването:</xsl:text>
										</span>
										<br/>
										<xsl:for-each select="cr:description">
											<span style="font-size:16px; margin-left:1.5cm; ">
												<xsl:text>Вид промяна: </xsl:text>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="cr:page_numbers">
											<span style="font-size:16px; margin-left:1.5cm; ">
												<xsl:text>Друга информация: оптичен архив състоящ се от </xsl:text>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
											<span style="font-size:16px; ">
												<xsl:text> страници.</xsl:text>
											</span>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="cr:creditors">
											<span style="font-size:16px; margin-left:1cm; ">
												<xsl:text>Вписаните права са на: </xsl:text>
											</span>
											<br/>
											<span style="font-size:16px; font-weight:bold; margin-left:1.5cm; ">
												<xsl:value-of select="position()"/>
											</span>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text>.</xsl:text>
											</span>
											<span style="font-size:16px; ">
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:for-each select="cr:participant">
												<xsl:for-each select="cr:particip_id_code">
													<span style="font-size:16px; ">
														<xsl:text>Идентификационен код: </xsl:text>
													</span>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
												<span style="font-size:16px; margin-left:2cm; ">
													<xsl:text>Име: </xsl:text>
												</span>
												<xsl:for-each select="cr:full_name">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
												<span style="font-size:16px; margin-left:2cm; ">
													<xsl:text>Адрес: </xsl:text>
												</span>
												<xsl:for-each select="cr:zip">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>&#160;</xsl:text>
													</span>
												</xsl:for-each>
												<xsl:for-each select="cr:city">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>, </xsl:text>
													</span>
												</xsl:for-each>
												<xsl:for-each select="cr:address">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
											</xsl:for-each>
										</xsl:for-each>
										<xsl:for-each select="cr:debtors">
											<xsl:if test="count(cr:participant) &gt; 0">
												<br/>
												<span style="font-size:16px; margin-left:1cm; ">
													<xsl:text>Вписването е по партида на:</xsl:text>
												</span>
												<br/>
												<span style="font-size:16px; font-weight:bold; margin-left:1.5cm; ">
													<xsl:value-of select="position()"/>
												</span>
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:text>.</xsl:text>
												</span>
											</xsl:if>
											<span style="font-size:16px; ">
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:for-each select="cr:participant">
												<xsl:for-each select="cr:particip_id_code">
													<span style="font-size:16px; ">
														<xsl:text>Идентификационен код: </xsl:text>
													</span>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
												<span style="font-size:16px; margin-left:2cm; ">
													<xsl:text>Име: </xsl:text>
												</span>
												<xsl:for-each select="cr:full_name">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
												<span style="font-size:16px; margin-left:2cm; ">
													<xsl:text>Адрес: </xsl:text>
												</span>
												<xsl:for-each select="cr:zip">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<xsl:if test="string-length( cr:zip )&gt;0">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>, </xsl:text>
													</span>
												</xsl:if>
												<xsl:for-each select="cr:city">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<xsl:if test="string-length( cr:zip )&gt;0 or string-length( cr:city )&gt;0">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>, </xsl:text>
													</span>
												</xsl:if>
												<xsl:for-each select="cr:address">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
												<br/>
											</xsl:for-each>
										</xsl:for-each>
										<div style="font-size:16px; ">
											<xsl:for-each select="cr:opis_header[string-length(../cr:oa_pole17)&gt;0]">
												<br/>
												<span style="font-size:16px; font-weight:bold; margin-left:0.5cm; ">
													<xsl:apply-templates/>
												</span>
											</xsl:for-each>
											<xsl:for-each select="cr:oa_pole17">
												<xsl:for-each select="cr:oas">
													<xsl:if test="string-length(../../cr:opis_header) &gt; 0">
														<xsl:for-each select="cr:regId">
															<span style="font-size:16px; font-weight:bold; ">
																<xsl:text>&#160;</xsl:text>
															</span>
															<span style="font-size:16px; font-weight:bold; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</xsl:if>
													<xsl:for-each select="cr:imgFace">
														<br/>
														<img style="font-size:16px; ">
															<xsl:attribute name="src">
																<xsl:if test="substring(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), 2, 1) = ':'">
																	<xsl:text>file:///</xsl:text>
																</xsl:if>
																<xsl:value-of select="translate(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), '&#x5c;', '/')"/>
															</xsl:attribute>
															<xsl:attribute name="alt"/>
														</img>
													</xsl:for-each>
													<xsl:for-each select="cr:imgBack">
														<br/>
														<img style="font-size:16px; ">
															<xsl:attribute name="src">
																<xsl:if test="substring(string(concat(&quot;data:&quot;, ../cr:imgBackType, &quot;;base64,&quot;, string(.))), 2, 1) = ':'">
																	<xsl:text>file:///</xsl:text>
																</xsl:if>
																<xsl:value-of select="translate(string(concat(&quot;data:&quot;, ../cr:imgBackType, &quot;;base64,&quot;, string(.))), '&#x5c;', '/')"/>
															</xsl:attribute>
															<xsl:attribute name="alt"/>
														</img>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
										</div>
									</xsl:for-each>
									<br/>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="cr:entry">
								<xsl:for-each select="cr:oa_extraPages">
									<br/>
									<xsl:if test="count(cr:oas)&gt;0">
										<br/>
										<br/>
									</xsl:if>
									<xsl:for-each select="cr:oas">
										<div style="background-color:#00c0ff; border:1px; border-color:#003d80; border-style:solid; font-size:16px; padding:5px; text-align:center; ">
											<xsl:choose>
												<xsl:when test="cr:img_side = &apos;FACE&apos;">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>Лице на страница № </xsl:text>
													</span>
												</xsl:when>
												<xsl:when test="cr:img_side = &apos;BACK&apos;">
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>Гръб на страница №</xsl:text>
													</span>
												</xsl:when>
												<xsl:otherwise>
													<span style="font-size:16px; font-weight:bold; ">
														<xsl:text>Страница №</xsl:text>
													</span>
													<span style="font-size:16px; ">
														<xsl:text>&#160;</xsl:text>
													</span>
												</xsl:otherwise>
											</xsl:choose>
											<xsl:for-each select="cr:sheet">
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:apply-templates/>
												</span>
											</xsl:for-each>
											<span style="font-size:16px; font-weight:bold; ">
												<xsl:text> към вписване № </xsl:text>
											</span>
											<xsl:for-each select="cr:regId">
												<span style="font-size:16px; font-weight:bold; ">
													<xsl:apply-templates/>
												</span>
											</xsl:for-each>
										</div>
										<br/>
										<xsl:choose>
											<xsl:when test="string-length(cr:imgFace) &gt; 0">
												<xsl:for-each select="cr:imgFace">
													<img style="font-size:16px; ">
														<xsl:attribute name="src">
															<xsl:if test="substring(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), 2, 1) = ':'">
																<xsl:text>file:///</xsl:text>
															</xsl:if>
															<xsl:value-of select="translate(string(concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))), '&#x5c;', '/')"/>
														</xsl:attribute>
														<xsl:attribute name="alt"/>
													</img>
												</xsl:for-each>
											</xsl:when>
											<xsl:otherwise>
												<span style="font-size:16px; ">
													<xsl:text>Няма налична информация</xsl:text>
												</span>
											</xsl:otherwise>
										</xsl:choose>
										<br/>
										<br/>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
