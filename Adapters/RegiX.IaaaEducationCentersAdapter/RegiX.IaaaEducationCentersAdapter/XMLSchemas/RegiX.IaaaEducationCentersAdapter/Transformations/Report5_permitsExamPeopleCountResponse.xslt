<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/Iaaa/EducationCenters" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsExamPeopleCountReportResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<br/>
					<h3 align="center">
						<span>
							<xsl:text>Изпълнителна агенция „Автомобилна администрация“;</xsl:text>
						</span>
					</h3>
					<h3 align="center">
						<span>
							<xsl:text>Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка по ЕИК и период за брой обучени лица в център за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им.</xsl:text>
						</span>
					</h2>
					<xsl:choose>
						<xsl:when test="count(  n1:PermitsExamPeopleCountResponse/n1:PermitsExamPeopleCounts ) = 0">
							<span>
								<xsl:text>Няма намерени данни в регистъра!</xsl:text>
							</span>
						</xsl:when>
						<xsl:otherwise>
							<xsl:for-each select="n1:PermitsExamPeopleCountResponse">
								<xsl:for-each select="n1:PermitsExamPeopleCounts">
									<xsl:for-each select="n1:PermitExamPeopleCount">
										<br/>
										<p>
											<span style="font-style:italic; ">
												<xsl:text>Разрешение</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:value-of select="position()"/>
											</span>
											<span style="font-style:italic; ">
												<xsl:text> от </xsl:text>
											</span>
											<span style="font-style:italic; ">
												<xsl:value-of select="count(../n1:PermitExamPeopleCount)"/>
											</span>
										</p>
										<table border="1" width="100%">
											<tbody>
												<tr>
													<td align="center" colspan="2">
														<p align="center">
															<span style="font-weight:bold; ">
																<xsl:text>Данни за разрешения</xsl:text>
															</span>
														</p>
													</td>
												</tr>
												<tr>
													<td colspan="2">
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Номер на разрешение</xsl:text>
														</span>
														<span style="font-size:15px; ">
															<xsl:text>: </xsl:text>
														</span>
														<xsl:for-each select="common:Number">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; ">
															<xsl:text>: </xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Име на фирмата от разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:CompanyFullName">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>ЕИК/БУЛСТАТ на фирмата от разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:CompanyIdentNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Име на управител на фирмата:</xsl:text>
														</span>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<xsl:for-each select="common:ManagerFullName">
															<xsl:apply-templates/>
														</xsl:for-each>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>ЕГН на управител на фирмата: </xsl:text>
														</span>
														<xsl:for-each select="common:ManagerIdentNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Адрес на фирмата: </xsl:text>
														</span>
														<xsl:for-each select="common:Address">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Тип на разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:PermitType">
															<xsl:apply-templates/>
														</xsl:for-each>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Дата на издаване на разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:IssueDate">
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
															<span style="font-size:15px; ">
																<xsl:text> г.</xsl:text>
															</span>
														</xsl:for-each>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Дата на валидност на разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:ValidTo">
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
															<span style="font-size:15px; ">
																<xsl:text> г.</xsl:text>
															</span>
														</xsl:for-each>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Дата на прекратяване на разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:CeaseDate">
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
															<span style="font-size:15px; ">
																<xsl:text> г.</xsl:text>
															</span>
														</xsl:for-each>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Пълно име на технически сътрудник:</xsl:text>
														</span>
														<xsl:for-each select="common:TechAssistantFullName">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>ЕГН нa технически сътрудник:</xsl:text>
														</span>
														<xsl:for-each select="common:TechAssistantIdentNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160; </xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Име на Регионалната дирекция в която работи разрешението:</xsl:text>
														</span>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<xsl:for-each select="common:OrgUnitShortName">
															<xsl:apply-templates/>
														</xsl:for-each>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Статус на разрешението: </xsl:text>
														</span>
														<xsl:for-each select="common:Status">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Брой кабинети за даденото разрешение:</xsl:text>
														</span>
														<xsl:for-each select="common:ExamRoomsCount">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Брой места за обучение: </xsl:text>
														</span>
														<xsl:for-each select="common:SeatPlacesCount">
															<xsl:apply-templates/>
														</xsl:for-each>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Брой места за изпит: </xsl:text>
														</span>
														<xsl:for-each select="common:ExamSeatsCount">
															<xsl:apply-templates/>
														</xsl:for-each>
														<span style="font-size:15px; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<br/>
														<span style="font-size:15px; font-weight:bold; ">
															<xsl:text>Брой изпитани лица от даденото разрешение: </xsl:text>
														</span>
														<xsl:for-each select="n1:ExamPeopleCount">
															<xsl:apply-templates/>
														</xsl:for-each>
														<br/>
													</td>
												</tr>
											</tbody>
										</table>
										<br/>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
					<br/>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>